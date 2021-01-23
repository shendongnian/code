    var myClass = MyClass.Create(); // where create is a static
    // or
    var myClass = MyClassFactory.Create(); // using a separate factory
    // or
    var myClass = MyClass.CreateFromTestData(value1, value2, value3); // etc
