    public void HashText()
    
    {
    
    string textToHash = "password"; 
    string saltAsString = Guid.NewGuid().ToString();
    byte[] byteRepresentation = UnicodeEncoding.UTF8.GetBytes( textToHash + saltAsString);
    
    byte[] hashedTextInBytes = null; 
    MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
    hashedTextInBytes = myMD5.ComputeHash(byteRepresentation); 
    string hashedText = Convert.ToBase64String(hashedTextInBytes); 
    // will display X03MO1qnZdYdgyfeuILPmQ==
    
    MessageBox.Show(hashedText);
    }
