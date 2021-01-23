    var arr = new UnlimitedGenericArray<int>(new Dictionary<Type,Func<object,int>>()
    {
        { typeof(string), v => int.Parse(v.ToString()) }
    });
    
    // ok! int == T
    arr.AddItem(123); 
    // ok, a mapping is provided
    arr.AddItem("123"); 
    // Error! 
    //"I don't know how to convert the value: False of type System.Boolean into type System.Int32!"
