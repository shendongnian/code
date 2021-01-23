    public byte[] GetFile(string filename)
    {
        try { return File.ReadAllBytes(filename); }
        catch { return null; }
    }
