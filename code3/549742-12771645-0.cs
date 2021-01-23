    static TextReader input = Console.In;
    static void Main(string[] args)
    {
        if (args.Any())
        {
            var path = args[0];
            if (File.Exists(path))
            {
                input = File.OpenText(path);
            }
        }
        
        // use `input` for all input operations
        for (string line; (line = input.ReadLine()) != null; )
        {
            Console.WriteLine(line);
        }
    }
