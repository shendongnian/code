    string searchKeyword = "England";
    string fileName = @"C:\Users\karansha\Desktop\search tab.txt";
    string[] textLines = File.ReadAllLines(fileName);
    Dictionary<string,int> results = new Dictionary<string,int>;
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            if(results.Keys.Any(searchKeyword))
            {
                results[searchKeyword]++;
            }
            else
            {
                results.Add(searchKeyword,1);
            }
            results.Add(line);
        }
    }
    foreach(var item in results)
    {
        Console.WriteLine("Team:"+item.Key +"\nPlayer Count:"+item.Value);
    }
