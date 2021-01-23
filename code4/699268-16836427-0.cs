    A1=new A();
    var props = typeof(A).GetProperties();
    Dictionary<string, string> output=new Dictionary<string,string>();
    foreach( var pi in props)
    {
        var name = pi.Name,
        var value= pi.GetValue(this, null));
        output[name]=value;
    }
