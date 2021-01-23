       Dictionary<string, object> d1 = new Dictionary<string, object>();
       d1.Add("first", new { Name = "TestName", Age = 12, ID = 001 }); 
    
       Dictionary<string, object> d2 = new Dictionary<string, object>();
       d2.Add("first", new { Name = "TestName", Age = 12, ID = 001 });
    
       Console.WriteLine(d1.SequenceEqual(d2)); //outputs True                
