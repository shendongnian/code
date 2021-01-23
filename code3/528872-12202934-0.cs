    var o =
      (from c in x
       group c by c.Date.Date into cc
       select new 
       { 
          Group = cc.Key.Date, 
          Items = cc.OrderByDescending(a=>a.Date.Time).ToList(),
          ItemCount = cc.Count() 
       }).OrderByDescending(p => p.Group);
