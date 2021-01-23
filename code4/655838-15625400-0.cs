    List<Score> list = new List<Score>(); // Not really necessary because you assign it a different value in the next line.
    list = topScores();
    ...
    System.Console.WriteLine("x{0}", list.Length);
    System.Console.WriteLine("TOP SCORES:");
    foreach (var score in list) {
        System.Console.WriteLine(score.GetScore());
    }
