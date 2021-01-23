    var dic = Dictionary<Regex, MyClass>()
    dic.Add(new Regex("..."), new MyClass)
    ....
    foreach(var match in dic.Keys.Where(k => k.IsMatch(str)))
    {
        var myClass = dic[match];
        ....
    }
    
