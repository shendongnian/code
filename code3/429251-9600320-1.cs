    var replacements = new Dictionary<string, string>
                           {
                               { "do|g", "cat" },
                               { "ca^t", "mouse" },
                               { "mo$$use", "raptor" }
                           };
    
    var source = "My do|g ate a ca^t which once ate a mo$$use";
    
    var regexPattern = 
        "(" + 
        string.Join("|", replacements.Keys.Select(Regex.Escape)) +
        ")";
    
    var regex = new Regex(regexPattern);
    
    var result = regex.Replace(source, match => replacements[match.Value]);
    // Now result == "My cat ate a mouse which once ate a raptor"
