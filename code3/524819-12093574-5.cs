    var selectedDictionary = ToGroupDictionary(selected);
    // ["banana", 2]
    // ["cherry", 1]
    // ["kiwi", 1]
    // ["strawberry", 1]
    foreach(string test in lookup)
    {
        var testDictionary = ToGroupDictionary(test);
        testDictionary.Keys.ToList().ForEach(k =>
            Console.WriteLine(selectedDictionary.ContainsKey(k) && 
                selectedDictionary[k] >= testDictionary[k]));
        // [0] :=
        // ["banana", 1]
        // ["strawberry", 1]
        // true, banana and strawberry exist
        // [1] :=
        // ["strawberry", 1]
        // true, strawberry exists
        // [2] :=
        // ["banana", 3]
        // false, too many bananas
    }            
