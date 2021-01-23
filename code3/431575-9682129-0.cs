    public string UserNameAsHexDump  {
            get
            {
    
                char[] ca = username.ToCharArray();
    
                string output = "";
                foreach (char c in ca)
                {
                    output += string.Format("{0} - {1:X4}\r\n", c, (uint)c);
                }
    
                return output;
    
            }
        }
