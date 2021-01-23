    request.Split('+').ToList<string>().ForEach(p =>
    {
        string[] tmp = p.Split('=');
    
        if (tmp.Length == 2 && !string.IsNullOrWhiteSpace(tmp[1]))
        {
            // edit - if your string can have duplicates, use
            // Dictionary<U,K>.ContainsKey(U) to check before adding
            var key = tmp[0];
            var value = tmp[1];
            if(!arguments.ContainsKey(key))
            {
                arguments.Add(key, value);
            }
            else
            {
                //overwrite with new value
                //could also maybe throw on duplicate or some other behavior.
                arguents[key]=value; 
            }
        }
        else
            throw InvalidOperationException("Bad dictionary string value");
    });
