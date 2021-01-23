    public bool SaveFile(string filename, object source)
    {
        bool result = true;
        StringBuilder exportText = new StringBuilder(source.ToString());
        try {
           try {
            File.WriteAllText(filename, exportText.ToString());
           } catch(Exception e) {  }
        }
        catch (Exception e)
        {
            OnPluginError(new ErrorEventArgs(e));
            result = false;
        }
    
        return result;
    }
