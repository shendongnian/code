    ssEntities sss = new ssEntities();
      var c1 = sss.table1.ToList().Where(x => x.date >= DateTime.Today)
                                .Select(x => new { x.Prop1, x.Prop2 });
      var c2 = sss.table2.ToList().Where(x => x.date1 >= DateTime.Today)
                                .Select(x => new { x.Prop1, x.Prop2 });
      var ll = c1.Union(c2).ToList();
