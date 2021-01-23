    bool a1 = _check.CompareMyValue(1, 1); 
    System.Diagnostics.Debug.Print(a1.ToString()); // prints true
    bool a2 = _check2.CompareMyValue("xyz", "xyz");
    System.Diagnostics.Debug.Print(a2.ToString()); // prints true
    bool a3 = _check2.CompareMyValue("x", "y"); // another example
    System.Diagnostics.Debug.Print(a3.ToString()); // prints false
