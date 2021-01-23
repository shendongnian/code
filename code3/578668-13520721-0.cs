    string str = "foo\n\r\nbar";
    using (Stream ms = new MemoryStream(Encoding.ASCII.GetBytes(str)))
    using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
    {
        string str2 = sr.ReadToEnd();
        Console.WriteLine(string.Join(",", str2.Select(c => ((int)c))));
    }
    // Output: 102,111,111,10,13,10,98,97,114
    //           f   o   o \n \r \n  b  a   r
