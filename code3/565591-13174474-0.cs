    static void Process(string input)
    {
        using (var reader = new StringReader(input))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if(line.Length == 0) continue;
                char first = line[0];
                string rest = line.Substring(1);
                // ... process this line
            }
        }
    }
