    string sample = new string((char) 312, 1);
    Encoding encoding = Encoding.GetEncoding(1252);
    string test = HttpUtility.UrlEncode(sample);
    Console.WriteLine("UTF8 Ecoded: {0}, round-trip = {1}", test, sample == HttpUtility.UrlDecode(test));
    test = HttpUtility.UrlEncode(sample, encoding);
    Console.WriteLine("1252 Ecoded: {0}, round-trip = {1}", test, sample == HttpUtility.UrlDecode(test, encoding));
    Console.ReadLine();
