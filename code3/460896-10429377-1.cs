      //Anonymous Type
        var result=(from item in context.table
            select new{
                 field1=... ,
                 field2=... ,
                 field3=...            }).ToList(); 
  
         //var anyType = new
        //{
        //    IntID = 1,
        //    StringName = "Wriju"
        //};
      if(result.Count()>0)
      {
        Type t = result[0].GetType();
   
       //Using LINQ get all the details of Property
    
        var pi = (from p in t.GetProperties()
    
                    select p).ToList();
       foreach (PropertyInfo p in pi)
       {
        //Get the name of the prperty
        Console.WriteLine(p.Name);
       }
       }
