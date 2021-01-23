    addExtension(this Dictionary<string, object> dictionary, string key, object value)
       {
            if(dictionary.Count == 50)
                    dictionary.Remove(dictionary.Last().Key);  
    
            dictionary.Add(key, value);   
       }
