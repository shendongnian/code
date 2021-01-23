    private bool IsBinaryFile(string filePath, int sampleSize = 10240)
    {
        if (!File.Exists(filePath))
            throw  new ArgumentException("File path is not valid", filePath);
     
        var buffer = new char[sampleSize];
        string sampleContent;
     
        using (var sr = new StreamReader(filePath))
        {
            int length = sr.Read(buffer, 0, sampleSize);
            sampleContent = new string(buffer, 0, length);
        }
     
        //Look for 4 consecutive binary zeroes
        if (sampleContent.Contains("\0\0\0\0"))
            return true;
     
        return false;
    }
