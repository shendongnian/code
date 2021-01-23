    List<string> lines = new List<string>(textFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
    for (int iLine = 0; iLine < lines.Count; iLine++)
    {
        List<string> values = new List<string>(lines[iLine].Split(new[] {","}, StringSplitOptions.None));
            for (int iValue = 0; iValue < values.Count; iValue++)
                Console.WriteLine(String.Format("Line {0} Value {1} : {2}", iLine, iValue, values[iValue]));
    }
