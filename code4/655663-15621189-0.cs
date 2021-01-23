    // A nice abstraction to hold the scores instead of two separate arrays.
    public class ScoreKeeper
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    var scores = new List<ScoreKeeper>();
    for (int i = 0; i < MAX; i++)
    {
        Console.Write("Enter a name and a score for player #{0}: ", (i + 1));
        string input = Console.ReadLine();
        if (input == "")
        {
            // If nothing is entered, it will break the loop.
            break; 
        }
        // Splits the user data into 2 arrays (integer and string).
        
        string[] separateInput = input.Split();
        
        scores.Add(new ScoreKeeper { Name = separateInput[0], Score = int.Parse(separateInput[1]) };
    }
    static void CalculateScores(ICollection<ScoreKeeper> scores)
    {
        // We take advantage of Linq here by gathering all the
        // scores and taking their average.
        var average = scores.Select(s => s.Score).Average();
        Console.WriteLine("The average score was {0}", average);
    }
