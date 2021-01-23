    public void LoadFile(string fileName)
    {
        try
        {
            var path = Path.GetFullPath(fileName);
        }
        catch (NotSupportedException e)
        {
            throw new ArgumentException(...);
        }
    }
