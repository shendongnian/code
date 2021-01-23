    var objs = somelist.Where(x => x.Id == 1);
    foreach (var prop in objs.First().GetType().GetProperties())
    {
      int x = 0;
      foreach (var obj in objs)
      {        
        if (prop.PropertyType.Name.Equals("Int32"))
        {
          int val = (int)prop.GetValue(obj, null);
          Console.WriteLine("Obj #{0}: {1} = 0x{2:x8}", x++, prop.Name, val);
        }
        else if (prop.PropertyType.Name.Equals("Decimal"))
        {
          int val = (decimal)prop.GetValue(obj, null);
          Console.WriteLine("Obj #{0}: {1} = {2:c2}", x++, prop.Name, val);
        }
        else
        {
          Console.WriteLine("Obj #{0}: {1} = '{2}'", x++, prop.Name, prop.GetValue(obj, null));
        }
      }
    }
