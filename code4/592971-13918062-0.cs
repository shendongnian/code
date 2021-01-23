    public class Score
    {
        public int Points { get; set; }
        public string Player { get; set; }
    }
    
    List<Score> top5 = (from s in allScores select s)
                       .OrderByDescending(s => s.Points)
                       .Take(5);
