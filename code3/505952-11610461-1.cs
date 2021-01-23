    public static IEnumerable<BowlingGame> ParseFile()
    {
       List<BowlingGame> games = new List<BowlingGame>();
       foreach (string line in File.ReadAllLines(@"c:\temp\test.csv"))
            games.Add(ParseGame(line));
       return games;
    }
    private static BowlingGame ParseGame(string line)
    {
        var scores = new List<double>();
        foreach (string s in line.Split(new[] { ',', ' ' }))
        {
            double score;
            if (Double.TryParse(s, out score))            
                 scores.Add(score);
        }
        return new BowlingGame(scores);
    }
