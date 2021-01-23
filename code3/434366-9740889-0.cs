    IEnumerable<string> ReadWords(StreamReader reader)
    {
        string line;
        while((line = reader.ReadLine())!=null)
        {
            foreach(string word in line.Split(new [1] {' '}, StringSplitOptions.RemoveEmptyEntries))
            {
                yield return word;
            }
        }
    }
