    Encoding utf8 = Encoding.UTF8;
    string testString = "café";
    byte[] utfBytes = utf8.GetBytes(testString); // 5 bytes
    
    Encoding iso = Encoding.GetEncoding("ISO-8859-1");
    byte[] isoBytes = iso.GetBytes(testString); // 4 bytes
    byte[] convertedUtf8Bytes = Encoding.Convert(utf8, iso, utfBytes); // 4 bytes
    
    string msg = iso.GetString(isoBytes);
    string msgConverted = iso.GetString(convertedUtf8Bytes);
    
    Console.WriteLine(msg);
    Console.WriteLine(msgConverted);
