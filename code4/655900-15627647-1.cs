    // instantiate a few instances of Class1
    var c1 = new Class1 { Name = "Foo", Address = "Bar" };
    var c2 = new Class1 { Name = "Baz", Address = "Boz" };
    // instantiate a collection
    var list = new System.Collections.Generic.List<Class1>();
    
    // add the instances
    list.Add( c1 );
    list.Add( c2 );
    
    // use foreach to access each item in the collection
    foreach( var item in list ){
       System.Diagnostics.Debug.WriteLine( item.Name );
    }
