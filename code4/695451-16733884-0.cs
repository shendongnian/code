    string pwd = "786";   // The original string
    UnicodeEncoding u = new UnicodeEncoding();
    byte[] x = u.GetBytes(pwd);  // The Unicode bytes of the string above
    // Convert bytes to a base64 string
    string b64 = Convert.ToBase64String(x);
    Console.WriteLine(b64);
    // Go back to the plain text string    
    byte[] b = Convert.FromBase64String(b64);
    string result = u.GetString(b);
    Console.WriteLine(result);
