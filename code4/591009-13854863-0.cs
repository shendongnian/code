    int query = (from p in db
                  where p.grade == "D"
                  select p.price).Count();
    
     if (query > 0)
     {
        System.Console.WriteLine("Found");
     }
      else
     {
        System.Console.WriteLine("Not Found");
     }
