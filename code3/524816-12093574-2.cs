    var selectedDictionary = ToGroupDictionary(selected);
    // ["banana", 2]
    // ["cherry", 1]
    // ["kiwi", 1]
    // ["strawberry", 1]
    foreach(string test in lookup)
    {
        var testDictionary = ToGroupDictionary(test);
        foreach (string key in testDictionary.Keys)
        {
            Console.WriteLine(selectedDictionary.ContainsKey(key) &&
                selectedDictionary[key] >= testDictionary[key]);
        }
        // [0] :=
        // ["banana", 1]
        // ["strawberry", 1]
        // [1] :=
        // ["strawberry", 1]
        // [2] :=
        // ["banana", 3]
    }            
