    var stringTest =new  GenericTest<string>(1);
    var objectTest = new GenericTest<object>(2);
    
    System.Diagnostics.Debug.Print(GenericTest<string>.StaticIntField.ToString()); //<-- prints 1
    System.Diagnostics.Debug.Print(GenericTest<object>.StaticIntField.ToString()); //<-- prints 2
    System.Diagnostics.Debug.Print(GenericTest<Control>.StaticIntField.ToString()); //<-- prints 0 because we haven't created an instance of this type yet
