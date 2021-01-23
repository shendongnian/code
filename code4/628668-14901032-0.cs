    public string Id { get; set; }
    public List<string> ColVal { get; set; }
    
    public C()
    {}
    
    public C(C objVar)
    {
        Id = objVar.Id;
       ColVal = objVar.ColVal; //<- Errors out: This is a collection type property, how do I get values & solve this?
    }
    }
