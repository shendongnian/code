    Dictionary<string, object> dic = new Dictionary<string,object>() {
    
        { "LastName", "Doe"  },
        { "FirstName", "Joe" },
        { "Age", 35 }
    };
    
    dynamic o = new System.Dynamic.ExpandoObject();
               
    foreach(var e in dic)
    {
        var oo = o as IDictionary<String, object>;
        oo[e.Key] = e.Value;
    }
    
    foreach(var a in o)
    {
        Console.WriteLine("{0}={1}", a.Key, (o as IDictionary<String, object>)[a.Key]);
    }
