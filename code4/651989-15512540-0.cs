    public void Serialize(String path, byte[,] myArray)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, myArray);
        }
    }
