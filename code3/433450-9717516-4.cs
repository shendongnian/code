    var result = from line in text.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                 let  tokens = line.Split(new[] {':'})
                 select tokens;
    
    Dictionary<string, string> = 
           result.ToDictionary (key => key[0].Trim(), value => value[1].Trim());
