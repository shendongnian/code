    private static Dictionary<string, Dictionary<string, List<string>>> _NestedDictionary = new Dictionary<string, Dictionary<string, List<string>>>();
    private void DoSomething()
    {
        var outerKey = "My outer key";
        var innerKey = "My inner key";
        Dictionary<string, List<string>> innerDictionary = null;
        List<string> listOfInnerDictionary = null;
        // Check if we already have a dictionary for this key.
        if (!_NestedDictionary.TryGetValue(outerKey, out innerDictionary))
        {
            // So we need to create one
            innerDictionary = new Dictionary<string, List<string>>();
            _NestedDictionary.Add(outerKey, innerDictionary);
        }
        // Check if the inner dict has the desired key
        if (!innerDictionary.TryGetValue(innerKey, out listOfInnerDictionary))
        {
            // So we need to create it
            listOfInnerDictionary = new List<string>();
            innerDictionary.Add(innerKey, listOfInnerDictionary);
        }
        // Do whatever you like to do with the list
        Console.WriteLine(innerKey + ":");
        foreach (var item in listOfInnerDictionary)
        {
            Console.WriteLine("   " + item);
        }
    }
