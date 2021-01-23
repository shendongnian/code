    Dictionary<string, List<string>> dictionary = new Dictionary<string,List<string>>();
    foreach(string key in keys) {
        if(!dictionary.ContainsKey(key)) {
            //add
            dictionary.Add(key, new List<string>());
        }
        dictionary[key].Add("theString");
    }
