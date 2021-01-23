    string input = "test_\\303\\246\\303\\270\\303\\245.txt";
    Encoding iso88591 = Encoding.GetEncoding(28591);
    Encoding utf8 = Encoding.UTF8;
    //Turn the octal literals into characters having codepoints 0-255
    //this results in a "binary string"
    string ofOctals = Regex.Replace(input, @"\\(?<num>[0-7]{3})", delegate(Match m)
    {
        String oct = m.Groups["num"].ToString();
        return Char.ConvertFromUtf32(Convert.ToInt32(oct, 8));
    });
    //Turn the "binary string" into bytes
    byte[] raw = iso88591.GetBytes(ofOctals);
    //Read the bytes into C# string
    string output = utf8.GetString(raw);
    Console.WriteLine(output);
    //test_æøå.txt
    
