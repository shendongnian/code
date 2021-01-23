    string c = "";
    var bytes = Encoding.UTF8.GetBytes(c);
    var cBack = Encoding.UTF8.GetString(bytes);
    using (var writer = new StreamWriter(@"c:\temp\char.txt", false, Encoding.UTF8))
    {
        writer.WriteLine(cBack);
    }
