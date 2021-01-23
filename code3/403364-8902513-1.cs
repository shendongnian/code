    string activeDir = "\\\\department\\shares\\users\\";
    string username = "username";
    string password = "password";
    
    WNet.AddConnection(activeDir, username, password);
    
    string newPath = System.IO.Path.Combine(activeDir, userID);
    System.IO.Directory.CreateDirectory(newPath);
