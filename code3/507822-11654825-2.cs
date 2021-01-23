    string convert = "This is the string to be converted";
    
    // From string to byte array
    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(convert);
    
    // From byte array to string
    string s = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
