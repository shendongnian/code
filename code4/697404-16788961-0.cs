    string input = "car[brand=saab][wheels=4]";
    
    var query = from s in input.Replace("]", "").Split('[')
                let vars = s.Split('=')
                let name = vars[0]
                let value = vars.Length > 1 ? vars[1] : ""
                select new {Name = name, Value = value};
    
    string firstVar = query.First().Name;
    Dictionary<string, string> otherVars = query
                                            .Skip(1)
                                            .ToDictionary(v => v.Name, v => v.Value);
