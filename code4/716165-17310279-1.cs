    void PassingByReference(List<int> collection)
    {
        // Compile error since method cannot change reference location
        // collection = new List<int>();
        collection.Add(1);
    }
    
    void ChangingAReference(ref List<int> collection)
    {
        // Allow to change location of collection with ref keyword
        collection = new List<int>();
        collection.Add(2);
    }
    
    var collection = new List<int>{ 5 };
    
    // Pass the reference of collection to PassByReference
    PassingByReference(collection);
    
    // collection new contains 1
    collection.Contains(5); // true
    collection.Contains(1); // true
    
    // Copy the reference of collection to another variable
    var tempCollection = collection;
    // Change the location of collection via ref keyword
    ChangingAReference(ref collection);
    
    // it is not the same collection anymore
    collection.Contains(5); // false
    collection.Contains(1); // false
    // compare the references use the default == operator
    var sameCollection = collection == tempCollection; // false
