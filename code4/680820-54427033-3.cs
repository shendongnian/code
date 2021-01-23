    // -- SERIALIZATION --
    
    // Initial object
    MyClass originObj = new MyClass { Property1 = 1988, Property2 = "Some data :D" };
    
    // "First level" Of serialization.
    string jsonString = JsonConvert.SerializeObject(originObj);
    Debug.WriteLine(jsonString);
    // Prints: 
    // {"Property1":1988,"Property2":"Some data :D"}
    
    
    // "Second level" of serialization.
    string escapedJsonString = JsonConvert.SerializeObject(jsonString);
    Debug.WriteLine(escapedJsonString);            
    // "{\"Property1\":1988,\"Property2\":\"Some data :D\"}"
    // Note the initial and final " character and de backslash characters
    
    // ...
    // at this point you could do more serializations ("More levels"), Obtaining as a result more and more backslash followed,
    // something like this:
    // "\"{\\\"Property1\\\":1988,\\\"Property2\\\":\\\"Some data :D\\\"}\""
    // Note that is... very very crazy :D
    // ...
    
    // -- DESERIALIZATION --
    
    // First deserialize to another string (unescaped string).
    string unescapedJsonString = JsonConvert.DeserializeObject<string>(escapedJsonString);
    Debug.WriteLine(unescapedJsonString);
    // Prints:
    // {"Property1":1988,"Property2":"Some data :D"}
    
    // ...
    // at this point you could repeat more deserializations to string, if necessary. For example if you have many backslash \\\
    // ...
    
    // Finally, perform final deserialization to the target type, using the last unescaped string.
    MyClass targetObject = JsonConvert.DeserializeObject<MyClass>(unescapedJsonString);
