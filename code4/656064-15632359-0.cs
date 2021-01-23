    char[] chars = new char[49];
    foreach(string line in File.ReadLines(path))
    {
        // copy in the data and pad with spaces
        line.CopyTo(0, chars, 0, Math.Min(line.Length,chars.Length));
        for (int i = line.Length; i < chars.Length; i++)
            chars[i] = ' ';
        // check every 6th character - if space replace with zero
        for (int i = 1; i < chars.Length; i += 6) if (chars[i] == ' ')
            chars[i] = '0';
        Console.WriteLine(chars);
    }
