    var mySortedDictionary = new SortedDictionary<int, object>();
    
    // ...
    // Add some values to dictionary
    // ...
    
    // Note, you will need the System.Linq namespace for First()
    int firstKey  = mySortedDictionary.Keys.First();
    object firstValue = mySortedDictionary[firstKey];
