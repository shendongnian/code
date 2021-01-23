    string searchKeyword = "England";
    string fileName = @"C:\Users\renan.stigliani\Desktop\search tab.txt";
    string[] textLines = File.ReadAllLines(fileName);
    List<string> results = new List<string>();
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            results.Add(line);
        }
    }
    int numberOfUsers = results.Distinct().Count();
    
    Console.WriteLine(numberOfUsers);
    // keep screen from going away
    // when run from VS.NET
    Console.ReadLine();
