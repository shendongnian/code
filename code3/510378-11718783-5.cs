    public void SaveToFile(string filePath)
    {
        try
        {
             string newFilePath = filePath.Replace(".bin", "");
             filestream = new FileStream(newFilePath + ".bin", FileMode.Create);
             BinaryFormatter b = new BinaryFormatter();
             b.Serialize(filestream, animals);
        }
        catch (Exception ex)
        {
            if (filestream != null) filestream.Close();
            //what you want
            //MessageBox.Show(ex.Message, "Warning!");
            throw (new Exception("Your custom message"));
        }
    }
