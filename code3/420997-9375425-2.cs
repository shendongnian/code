    public void saveBinary(object c, string filepath)
    {
        try
        {
            using (System.IO.Stream sr = System.IO.File.Open(filepath, System.IO.FileMode.Create))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(sr, c);
                sr.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public object loadBinary(string path)
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                using (System.IO.Stream sr = System.IO.File.Open(path, System.IO.FileMode.Open))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    object c = bf.Deserialize(sr);
                    sr.Close();
                    return c;
                }
            }
            else
            {
                throw new Exception("File not found");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return null;
    }
