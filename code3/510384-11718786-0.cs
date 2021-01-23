    public void SaveToFile(string filePath)
    {
        string newFilePath = filePath.Replace(".bin", "");
        using(ilestream = new FileStream(newFilePath + ".bin", FileMode.Create))
        {
            
            filestream = new FileStream(newFilePath + ".bin", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(filestream, animals);
        }
    }
