    IEnumerable<Tuple<int,int,int>> NumberTripletsFromText(string theText)
    {
        var results = new List<int>;
        var count = 0;
        foreach(var match in Regex.Matches(theText, "[0-9]+")
        {
            count++;
            results.Add(int.Parse(match.Value);
    
            if (count == 3)
            {
                yield return Tuple.Create(results[1], results[2], results[3]);
                results.Clear;
                count = 0;
            }
        }
        if (results > 0)
        {
           //Handle non divisible by three.
        }
    }
