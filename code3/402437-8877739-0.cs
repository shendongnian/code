    // You have lists of different types:
    List<double> doubleCollection = new List<double>();
    List<string> stringCollection = new List<string>();
    // Now to store generically:
    var collection = new List<List< /* ... Which type parameter to use? ... */ >>();
