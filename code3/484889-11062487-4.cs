    private void New_Score(int score, string name)
    {
      string filename = "scores.txt";
      List<string> scoreList;
      if (File.Exists(filename))
        scoreList = File.ReadAllLines(filename).ToList();
      else
        scoreList = new List<string>();
      scoreList.Add(name + " " + score.ToString());
      var sortedScoreList = scoreList.OrderByDescending(ss => int.Parse(ss.Substring(ss.LastIndexOf(" ") + 1)));
      File.WriteAllLines(filename, sortedScoreList.ToArray());
    }
