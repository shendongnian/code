    List<string> ReadAllNullTerminated(this System.IO.StreamReader rdr)
    {
        var stringsRead = new System.Collections.Generic.List<string>();
        var bldr = new System.Text.StringBuilder();
        int nc;
        while ((nc = rdr.Read()) != -1)
        {
            Char c = (Char)nc;
            if (c == '\0')
            {
                stringsRead.Add(bldr.ToString());
                bldr.Length = 0;
            }
            else
                bldr.Append(c);
        }
        // Optionally return any trailing unterminated string
        if (bldr.Length != 0)
            stringsRead.Add(bldr.ToString());
        return stringsRead;
    }
    
