    byte[] bytes = // ...
    
    // To  string 
    var str = Encoding.ASCII.GetString(bytes);
    // To bytes
    bytes = Encoding.ASCII.GetBytes(str);
