    string[] scores = System.IO.File.ReadAllLines("timesBetweenStartToEnd.txt");
    var orderedScores = scores.OrderBy(x => int.Parse(x.Split(' ')[8].Split(' ')[0]));
    
    foreach (var score in orderedScores)
    {
         System.IO.File.AppendAllText(@"logTimes.txt", string.Format("{0}{1}", score, Environment.NewLine));
    }
