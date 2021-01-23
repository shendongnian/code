    public static string ZipToBase64()
    {
        string filePath = @"C:\Users\John\Desktop\SomeArchive.zip";
        if (!string.IsNullOrEmpty(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            return Convert.ToBase64String(filebytes, 
                                          Base64FormattingOptions.InsertLineBreaks);
        }
            return null;
    }
