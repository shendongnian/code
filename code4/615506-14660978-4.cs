    using (var db = new HierarchyContext())
    {
        var level = new MainHierarchyLevel { Name = "Level1" };
        level = db.MainHierarchyLevels.Add(level);
        var mh = new MainHierarchyItem { Name = "m1", Description = "m1 desc", Level = level };
        db.MainHierarchyItems.Add(mh);
        db.SaveChanges();
        var query = from m in db.MainHierarchyItems
                    orderby m.Name
                    select m;
        Console.WriteLine("All mains in the database:");
        foreach (var item in query)
        {
            Console.WriteLine(item.Name);
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
  
