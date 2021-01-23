    public string TruncateWithPreservation(string s, int len)
    {
        string[] parts = s.Split(' ');
        StringBuilder sb = new StringBuilder();
    
        foreach (string part in parts)
        {
            if (sb.Length + part.Length > len)
                break;
    
            sb.Append(' ');
            sb.Append(part);
        }
    
        return sb.ToString();
    }
