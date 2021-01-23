    List<string> lines = new List<string>(textFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
    for (int iLine = 0; iLine < lines.Count; iLine++)
    {
        List<string> values = new List<string>(lines[iLine].Split(new[] {Environment.NewLine}, StringSplitOptions.None));
     }
