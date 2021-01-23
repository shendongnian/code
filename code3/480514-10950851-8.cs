    var mySortedDictionary = new SortedDictionary<float, int>();
    
    // ...
    // Add some values to dictionary
    // ...
    
    // Note, you will need the System.Linq namespace for First()
    float firstKey = mySortedDictionary.Keys.First();
    int firstValue = mySortedDictionary[firstKey];
    // If you just need the value:
    int firstValue2 = mySortedDictionary.Values.First();
