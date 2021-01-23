    public void SaveToFile(string filePath)
    {
        try
        {
            string newFilePath = filePath.Replace(".bin", "");
            filestream = new FileStream(newFilePath + ".bin", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(filestream, animals);
        }
        catch(Exception ex)
        {
            if (filestream != null) filestream.Close();
            throw;
            // but don't use
            // throw ex;
            // it throws everything same
            // except for the stacktrace
        }
        // or do it like this
        //catch(Exception ex)
        //{
        //    throw;
            // but don't use
            // throw ex;
            // it throws everything same
            // except for the stacktrace
        //}
        //finally
        //{
        //    if (filestream != null) filestream.Close();
        //}
            
    }
