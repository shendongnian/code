    var prefixes = new Dictionary<int, string>(); // Needs values
    
    var result = new List<string>();
    
    for (var i = 0; i < fileContents.Count; i++){
       string prefix;
    
       if (prefixes.TryGetValue(i, out prefix){ result.Add(string.Join(" ", prefix, fileContent[i])) }
       else { result.Add(fileContent[i]);}
    }
