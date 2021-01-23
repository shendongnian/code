    public void SaveToFile(string filePath)
    {
        string newFilePath = filePath.Replace(".bin", "");
        using(var filestream = new FileStream(newFilePath + ".bin", FileMode.Create))
        {
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(filestream, animals);
        }
    }
