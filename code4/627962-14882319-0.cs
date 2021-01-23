    HashSet<int> intTest = new HashSet<int>()
    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
    bool has4 = intTest.Contains(4);    // Returns true
    bool has11 = intTest.Contains(11);  // Returns false
    bool result = intTest.IsSupersetOf(new []{ 4, 6, 7 }); // Returns true
