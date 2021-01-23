    public string splitString(string str)
        {
    
            string[] FileName = str.Split('_');   
    
            if (FileName[1] != "")
            {
                return FileName[1];
            }
            else
            {
                return FileName[0];
            }
        }
