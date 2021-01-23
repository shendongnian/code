    public byte[,] Deserialize(String path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[,] myArray = (byte[,])formatter.Deserialize(stream);
        }
    }
