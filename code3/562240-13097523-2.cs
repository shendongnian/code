    byte[] bytes;
    using (var stream = new FileStream("input.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        var index = 0;
        var count = (int) stream.Length;
        bytes = new byte[count];
        while (count > 0)
        {
            int n = stream.Read(bytes, index, count);
            if (n == 0)
                throw new EndOfStreamException();
            index += n;
            count -= n;
        }
    }
    // test
    string s = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(s);
