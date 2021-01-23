    var str = "Some data\n?I?Message message\r\nAnother part of data\n";
    foreach (string line in str.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
    {
        var match = Regex.Match(line, @"(?<Message>\?(?<Type>\S)\?(?<Text>[\S\s]+(\r\n)+))");
        if (match.Success)
        {
            Console.WriteLine("match!");
            Console.WriteLine(match.Groups["Type"]);
            Console.WriteLine(match.Groups["Text"]);
        }
        else
        {
            Console.WriteLine("no match!");
            Console.WriteLine(line);
        }
    }
