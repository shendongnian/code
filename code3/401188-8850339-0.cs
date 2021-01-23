    var list = new[] {
                  new {Name="OB1", Prop=new[]{"A", "B", "C"}},
                  new {Name="OB2", Prop=new[]{"D", "C", "E"}},
                  new {Name="OB3", Prop=new[]{"B", "E", "C"}},
                };
    
    var props = from prop in (from item in list
                              from p in item.Prop
                              select p).Distinct()
                let names = list.Where(i => i.Prop.Contains(prop)).Select(i => i.Name).ToArray()
                select new { prop, names };
