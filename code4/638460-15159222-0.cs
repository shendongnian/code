    string searchKeyword = "England";
    string fileName = @"C:\Users\karansha\Desktop\search tab.txt";
    string[] textLines = File.ReadAllLines(fileName);
    List<string> results = new List<string>();
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            results.Add(line);
        }
    }
    List<string> users = results.Distinct().toList();
