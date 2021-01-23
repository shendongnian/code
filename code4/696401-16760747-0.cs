    TestClass1 myobject = ...;
    // get SubProperty from TestClass1
    TestClass2 subproperty = (TestClass2) myobject.GetType()
        .GetProperty("SubProperty")
        .GetValue(myobject, null);
    // get Address from TestClass2
    string address = (string) subproperty.GetType()
        .GetProperty("Address")
        .GetValue(subproperty, null);
