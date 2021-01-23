    var objs = somelist.Where(x => x.Id == 1);
    foreach (var prop in objs.First().GetType().GetProperties())
    {
      int x = 0;
      foreach (var obj in objs)
      {
        
        Console.WriteLine("Obj #{0}: {1} = {2}", x++, prop.Name, prop.GetValue(obj, null));
      }
    }
