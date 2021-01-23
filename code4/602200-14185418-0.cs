    List<string> lines = new List<string>();
    do
    {
        string line = Console.ReadLine();
        if(!string.IsNullOrEmpty(line))
        {
            lines.Add(line);
        }
    } while(!string.IsNullOrEmpty(line));
