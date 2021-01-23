    List<string> data = new List<string>
    (new string[]   { "Computer", "A", "B", "Computer", "B", "A" });
    int[] indexes = Enumerable.Range(0, data.Count).Where
                     (i => data[i] == "Computer").ToArray();
    Array.ForEach(indexes, i => data[i] = "Calculator");
