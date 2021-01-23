    public bool IsBusy(string filePath)
    {
        try
        {
            using (FileStream stream = File.OpenWrite(filePath))
            {
                stream.Close();
                return false;
            }
        }
        catch (IOException)
        {
            return true;
        }
    }
}
