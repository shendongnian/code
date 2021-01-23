      var o = 
        (from c in x 
         group c by c.Date into cc 
         select new { Group = cc.Key, ItemCount = cc.Count() });
        
        foreach (var grp in o)
        {
            Console.WriteLine("\nCategoryID Key = {0}:", grp.Key);
            foreach (var item in grp)
            {
                Console.WriteLine("\t{0}", item.Items);//Replace with your property
            }
        }
