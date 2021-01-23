    var obj = new MyObject();
    
    // map the object to a new dictionary        
    var dict = ObjectMapper.ToDictionary(obj);
    // iterate through each item in the dictionary, a key/value pair
    // representing each property 
    foreach (KeyValuePair<string,object> kvp in dict) {
        if (kvp.Value!=null && kvp.Value.GetType().IsClass) {
            dict[kvp.Key]=null;
        }
    }
    // map back to an instance
    var newObject = ObjectMapper.ToNew<MyObject>(dict);
