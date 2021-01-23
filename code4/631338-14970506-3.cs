    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        string s = @"C:\Test Folder\документи";
        Console.WriteLine(s);
        // input C:\Test Folder\документи
        var strInput = ReadLineUTF();
        Console.WriteLine(strInput);
    }
    static string ReadLineUTF()
    {
        ConsoleKeyInfo currentKey;
        var sBuilder = new StringBuilder();
        do
        {
            currentKey = Console.ReadKey();
            // avoid capturing newline
            if (currentKey.Key != ConsoleKey.Enter)
                sBuilder.Append(currentKey.KeyChar);
        }
        // check if Enter was pressed
        while (currentKey.Key != ConsoleKey.Enter);
        // move on the next line
        Console.WriteLine();
        return sBuilder.ToString();
    }
