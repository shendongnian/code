    var listOfCharacters = "abcdefghijklmnopqrstuvwxyz";
    var chars = listOfCharacters.ToList();
    
    string password = string.Empty;
    for (int i = 0; i < length; i++) {
        int x = random.Next(0, chars.Count);
    	
    	password += chars[x];
    	
    	chars.RemoveAt(x);
    	if (chars.Count == 0)
    		chars = listOfCharacters.ToList();
     }
    
     if (length < password.Length) password = password.Substring(0, length);
    
     return password;
