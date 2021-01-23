    IDs.Where(a=>a.ID = id)
       .Select(a => new A() 
       {
           ID = a.ID,
           Values = new List<B>()
           {
               new B() 
               { 
                   Code = a.Values.First().Code, 
                   DisplayName = a.Values.First().DisplayName 
               }
           }
        });
