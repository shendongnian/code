    string sample = new string((char)0x0DF, 1);
    string test = HttpUtility.UrlEncode(sample);
    Console.WriteLine("UTF8 Ecoded: {0}", test);
    test = HttpUtility.UrlEncode(sample, Encoding.GetEncoding(1252));
    Console.WriteLine("1252 Ecoded: {0}", test);
