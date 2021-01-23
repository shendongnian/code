    var c1 = new Class1();
    var c2 = new Class2();
    var c3 = new Class3();
    var c4 = new Class4();
    c1.Numbers = new List<int> {4, 5, 6}; // Works
    c1.Numbers.Clear(); // Works
    c2.Numbers = new List<int> {4, 5, 6}; // Error
    c2.Numbers = c2.Numbers; // Error - you just can't reassign it!
    c2.Numbers.Clear(); // Works - you are just calling the Clear method of the existing list object.
    c3.Numbers = new ReadOnlyCollection<int> {4, 5, 6}; // Works - the member is not readonly
    // ReadOnlyCollection doesn't allow to change it's elements after initializing it.
    // It doesn't even have these functions:
    c3.Numbers.Clear(); // Error
    c3.Numbers.Add(); // Error
    c3.Numbers.Remove(2); // Error
    c4.Numbers = new ReadOnlyCollection<int> {4, 5, 6}; // Error - the member is marked as readonly
    
    // ReadOnlyCollection doesn't allow to change it's elements after initializing it.
    // It doesn't even have these functions:
    c4.Numbers.Clear(); // Error
    c4.Numbers.Add(); // Error
    c4.Numbers.Remove(2); // Error
