        var results = from myRow in DataTable1.AsEnumerable()
        var results2 = from myRow in DataTable2.AsEnumerable()
        
        var results = from r in dtTable1.AsEnumerable()
              join c in dtTable2.AsEnumerable() on c.Field1 equals r.Field1
              select new List<object>(r.ItemArray).Concat(new List<object>() { c.Field2 })
