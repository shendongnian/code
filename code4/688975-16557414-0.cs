    List<Object> o = new List<Object>();
    for (int i = 0; i < 10; i++)
    {    
        var list = new[]
        {
            new { Number = i, Name = string.Concat("name",i) }
        };
    	o.Add(list);
    }
    
    o.Dump();
