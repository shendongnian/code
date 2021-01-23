    string regex = @"<([\w]+)\s+(?:(\w+)=[""']?([^\s""']+)[""']?\s*)+>";
    string html = @"<option foo=bar value=""1"" foo2='bar2'>...</option>
                    <option foo=bar value=""1"" foo2='bar2'>...</option>
                    <option foo=bar value=""1"" foo2='bar2'>...</option>";
    //Getting all the matches.
    var matches = Regex.Matches(html, regex);
    foreach (Match m in matches) {
        //This will contain the replaced string
        string result = string.Format("<{0}", m.Groups[1].Value);
        //Here we will store all the keys
        var keys = new List<string>();
        //Here we will store all the values
        var values = new List<string>();
        //For every pair (key, value) matched
        for (int i = 0; i < m.Groups[2].Captures.Count; i++) {
            //Get the key
            var key = m.Groups[2].Captures[i].Value;
            //Get the value
            var value = m.Groups[3].Captures[i].Value;
            //Insert on the list (if key is 'value', insert at the beginning)
            if (key == "value") {
                keys.Insert(0, key);
                values.Insert(0, value);
            }
            else {
                keys.Add(key);
                values.Add(value);
            }
        }
        
        //Concatenate all the (key, value) attributes to the replaced string
        for (int i = 0; i < keys.Count; i++) {
            result += string.Format(@" {0}=""{1}""", keys[i], values[i]);
        }
        
        //Close the tag
        result += ">";
        Console.WriteLine(result);
    }
