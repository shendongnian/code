    for (int k = 0; k < sayis.Length; k++)
    {
        string line = Console.ReadLine();
        if (!int.TryParse(line, out sayis[k]))
        {
            Console.WriteLine("Couldn't parse {0} - please enter integers", line);
            k--; // Go round again for this index
        }
    }
