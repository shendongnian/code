    public Encoding GetEncording(string filePath)
    {
        Encoding enc = Encoding.Default;
        using (var r = new StreamReader(filePath, detectEncodingFromByteOrderMarks: true))
        {
            enc = r.CurrentEncoding;
        }
        return enc;
    }
