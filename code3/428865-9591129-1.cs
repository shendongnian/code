      var stringTest =new  GenericTest<string>(1);
        var objectTest = new GenericTest<object>(2);
        
        System.Diagnostics.Debug.Print(stringTest.GetStaticFieldValue().ToString());
        System.Diagnostics.Debug.Print(objectTest.GetStaticFieldValue().ToString());
