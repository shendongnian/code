    var encoding = Encoding.GetEncoding("Windows-1252");
    string asString = System.IO.File.ReadAllText("C:/Temp/test.txt", encoding);
    byte[] asBytes = System.IO.File.ReadAllText("C:/Temp/test.txt");
    foreach(var entry in ParseFile(aString))
    {
        int start = entry.PositionInString;
        // Since we used a one-byte encoding, we can use this location
        // directly in the byte-array.
        int length = entry.Length;
        string encoding = entry.Encoding;
        string decodedEntry = Encoding.GetEncoding(encoding)
                                      .GetString(bytes, start, length);
        Console.WriteLine(decodedEntry);
    }
