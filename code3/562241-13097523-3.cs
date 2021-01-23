    byte[] bytes;
    using (var stream = new FileStream("input.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        var reader = new StreamReader(stream);
        string text = reader.ReadToEnd();
        bytes = Encoding.UTF8.GetBytes(text);
    }
    // test
    string s = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(s);
