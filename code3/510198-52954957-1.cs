    string ReadNullTerminated(this System.IO.StreamReader rdr)
    {
        var bldr = new System.Text.StringBuilder();
        int nc;
        while ((nc = rdr.Read()) > 0)
            bldr.Append((char)nc);
        return bldr.ToString();
    }
