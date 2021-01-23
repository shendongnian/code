        var expr = from d in xmlDoc.Descendants("ROW")
                            group d by new
                            {
                               ParentDir = d.Element("PARENT_DIR").Value,
                               Dir = d.Element("DIR").Value,
        
                            } into gDir
                            select new
                            {
                               GroupKey = gDir.Key,
                               Data = from z in gDir
                                      select new { FileName = z.Element("FILE_NAME").Value }
        
                            };
    
    foreach (var g in expr)
    {
       Console.WriteLine("{0}\t\t", g.GroupKey.ParentDir, g.GroupKey.Dir);
      
       foreach (var n in g.Data)
                   Console.WriteLine("\t\t{0}", n.FileName);
    }
