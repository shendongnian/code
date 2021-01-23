    class MyClass {public MyClass2 MyField;}
    class MyClass2 {public List<string> MyItems; public int? MyNullableField;}
    
    ...
    var myClass = null;
    //returns 0; myClass is null
    var result = myClass.ValueOrDefault(x=>x.MyField.MyItems.Count);
    myClass = new MyClass();
    //returns 0; MyField is null
    result = myClass.ValueOrDefault(x=>x.MyField.MyItems.Count);
    myClass.MyField = new MyClass2();
    //returns 0; MyItems is null
    result = myClass.ValueOrDefault(x=>x.MyField.MyItems.Count);
    myClass.MyField.MyItems = new List<string>();
    //returns 0, but now that's the actual result of the Count property; 
    //the entire chain is valid
    result = myClass.ValueOrDefault(x=>x.MyField.MyItems.Count);
    //returns null, because FirstOrDefault() returns null
    var myString = myClass.ValueOrDefault(x=>x.MyField.MyItems.FirstOrDefault());
    myClass.MyField.MyItems.Add("A string");
    //returns "A string"
    myString = myClass.ValueOrDefault(x=>x.MyField.MyItems.FirstOrDefault());
    //returns 0, because MyNullableField is null; the exception caught here is not an NRE,
    //but an InvalidOperationException
    var myValue = myClass.ValueOrDefault(x=>x.MyField.MyNullableField.Value);
