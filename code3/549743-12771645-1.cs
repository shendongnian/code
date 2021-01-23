    static void Main(string[] args)
    {
        if (args.Any())
        {
            var path = args[0];
            if (File.Exists(path))
            {
                Console.SetIn(File.OpenText(path));
            }
        }
        
        // Just use the console like normal
        for (string line; (line = Console.ReadLine()) != null; )
        {
            Console.WriteLine(line);
        }
    }
