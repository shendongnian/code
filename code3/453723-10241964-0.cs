    dynamic expando = new System.Dynamic.ExpandoObject();
    
    var myObj = new Dictionary<string, object>();
    
    myObj["myProperty"] = expando.myProperty;
