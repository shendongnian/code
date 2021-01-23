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
            MessageBox.Show(ex.Message, "Warning!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            throw (new Exception("Your custom message"));
        }
    }
