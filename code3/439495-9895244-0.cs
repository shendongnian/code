    public static String ReadUntil(this StreamReader sr, String delim)
    {
        StringBuilder sb = new StringBuilder();
        bool found = false;
    
        while (!found && !sr.EndOfStream)
        {
           for (int i = 0; i < delim.Length; i++)
           {
               Char c = (char)sr.Read();
               sb.Append(c);
    
               if (c != delim[i])
                   break;
    
               if (i == delim.Length - 1)
               {
                   sb.Remove(sb.Length - delim.Length, delim.Length);
                   found = true;
               }
            }
         }
    
         return sb.ToString();
    }
