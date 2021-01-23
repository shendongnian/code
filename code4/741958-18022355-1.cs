    StringBuilder sb = new StringBuilder(theText.Length);
    foreach (char c in theText)
    {
        switch (c)
        {
            case '\t' : sb.Append("\\t"); break;
            case '\r' : sb.Append("\\r"); break;
            case '\n' : sb.Append("\\n"); break;
            default : sb.Append(c); break;
        }
    }
    byte[] theChars = Encoding.ASCII.GetBytes(sb.ToString());
