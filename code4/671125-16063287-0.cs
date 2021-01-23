    public override string SaveStreamInTempFile()
    {
        string tempFileName = Path.GetTempFileName();
        using (var file = File.Open(tempFileName, FileMode.CreateNew))
        stream.CopyTo(file);
        return tempFileName;
    }
