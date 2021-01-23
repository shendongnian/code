    static void Main(string[] args)
    {
        // Consider using a list instead of an ArrayList (optional)
        List<string> lines = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "showme")
            {
                // Here we print each string and stats.
                foreach (string s in lines)
                {
                    Console.WriteLine(s); // Write the line.
                    Console.WriteLine("{0} contains {1} letters", s, s.Length); // Write the stats.
                }
            }
            else if (input == "end")
            {
                Environment.Exit(0);
            }
            else
            {
                // This is where you add your input string to the collection above.
                lines.Add(input);
            }
        }
    }
