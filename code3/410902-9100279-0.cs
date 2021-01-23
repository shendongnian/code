    List<string> linesList = new List<string>();
        
    foreach (string line in lines)
    {
          lineList.Add(Regex.Replace(line, filterLabels, ""));                    
    }
    
    lines = lineList.ToArray();
