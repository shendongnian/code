    private string GetSHA1String(string text)
    {
        var UE = new UnicodeEncoding(); var message = UE.GetBytes(text);
        
        var hashString = new SHA1Managed(); 
        var hex = string.Empty;
        
        var hashValue = hashString.ComputeHash(message); 
        foreach (byte b in hashValue)
        { 
            hex += String.Format("{0:x2}", b);
        } 
        
        return hex;
    }
