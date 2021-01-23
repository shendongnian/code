    public Bitmap ConvertBytesToImage(byte[] BytesToConvert)
    {
        MemoryStream ms = new MemoryStream(BytesToConvert);
        try { return new Bitmap(ms); }
        catch { return null; }
    }
