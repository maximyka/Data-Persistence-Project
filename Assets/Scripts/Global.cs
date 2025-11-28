using UnityEngine;
using System.IO;

public class Global : MonoBehaviour
{
    public static Global Instance;

    public int MaxScore; 

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor(); 
    }

    [System.Serializable]
    class SaveData
    {
        public int MaxScore;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.MaxScore = MaxScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxScore = data.MaxScore;
        }
    }


}