    string test = "敭畳灴獩楫n"; //incoming data. must be mesutpiskin 
    
    byte[] bytes = Encoding.Unicode.GetBytes(test);
    
    string s = string.Empty;
    
    for (int i = 0; i < bytes.Length; i++)
    {
        s += (char)bytes[i];
    }
    
    s = s.Trim((char)0);
    
    MessageBox.Show(s);
    //s=mesutpiskin 
