    public static Boolean IsProtected(String file)
    {
        Byte[] bytes = File.ReadAllBytes(file);
        String prefix = Encoding.Default.GetString(bytes.Take(2).ToArray());
            
        // Zip and not password protected.
        if (prefix == "PK")
            return false;
        // Office format.
        if (prefix == "ÐÏ")
        {
            // XLS 2003
            if (bytes.Skip(0x208).Take(1).ToArray()[0] == 0xFE)
                return true;
            // XLS 2005
            if (bytes.Skip(0x214).Take(1).ToArray()[0] == 0x2F)
                return true;
            // DOC 2005
            if (bytes.Skip(0x20B).Take(1).ToArray()[0] == 0x13)
                return true;
            // Guessing
            if (bytes.Length < 2000)
                return false;
            // DOC/XLS 2007+
            String start = Encoding.Default.GetString(bytes.Take(2000).ToArray()).Replace("\0", " ");
            if (start.Contains("E n c r y p t e d P a c k a g e"))
                return true;
            return false;
        }
        // Unknown format.
        return false;
    }
