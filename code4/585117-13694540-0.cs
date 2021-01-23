    string s = "safsadfd\r\ndfgfdg\r\n\r\ndfgfgg";
    string[] lines = s.Split('\n');
    for (int i = 0; i < lines.Length; i++)
    {
        if (string.IsNullOrWhiteSpace(lines[i]))
        //if (lines[i].Length == 0) //or maybe this suits better..
            Console.WriteLine(i);
    }
