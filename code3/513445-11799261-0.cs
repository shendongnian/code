    private string[] ReadFromFile(string path)
    {
        string[] data = null;
        try
        {
            data = File.ReadAllLines(path);
        }
        catch (Exception)
        {
            throw new Exception("message:<<Problem reading in file: " +e.getMessage() + ">>");
        }
    
        return data;
    }
