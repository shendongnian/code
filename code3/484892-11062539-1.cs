    static List<Highscore> ReadScoresFromFile(String path)
    {
        var scores = new List<Highscore>();
        using (StreamReader reader = new StreamReader(path))
        {
            String line;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                try
                {
                    scores.Add(new Highscore(line));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid score at line \"{0}\": {1}", line, ex);
                }
            }
        }
        return SortAndPositionHighscores(scores);
    }
