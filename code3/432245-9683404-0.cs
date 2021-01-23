    Encoding enc = new UTF8Encoding();
    string s = "abc";
    Console.WriteLine("new UTF8Encoding(), preamble: {0}",
        BitConverter.ToString(enc.GetPreamble()));
    Console.WriteLine("new UTF8Encoding(), payload: {0}",
        BitConverter.ToString(enc.GetBytes(s)));
    enc = Encoding.UTF8;
    Console.WriteLine("Encoding.UTF8, preamble: {0}",
        BitConverter.ToString(enc.GetPreamble()));
    Console.WriteLine("Encoding.UTF8, payload: {0}",
        BitConverter.ToString(enc.GetBytes(s)));
