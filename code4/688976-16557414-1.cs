    List<Object> o = new List<Object>();
    for (int i = 0; i < 10; i++)
    {    
     
    	o.Add(new { Number = i, Name = string.Concat("name",i) });
    }
    
    o.Dump();
