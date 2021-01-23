    var query = _session.QueryOver<Something>();
    if(someterm!=null)
       query.Where(x=>x.SomeTerm==someTerm);
        
    if(someotherterm!=null)
       query.Where(x=>x.SomeOtherTerm==someotherterm);
    var results = query.List();
