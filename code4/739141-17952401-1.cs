    var query =dt.AsEnumerable().GroupBy(item => item.Field<string>("ID"))
          .Select(g => {
             dynamic t = new System.Dynamic.ExpandoObject();
             if (g.Table.Columns.Any(c => c.ColumnName == "Status"))
              t.Status = g.Field<string>("Status");
             if (g.Table.Columns.Any(c => c.ColumnName == "Disc"))
              t.Disc = g.Field<string>("Disc");
  
             t.ID = g.Key;
             t.Loc = String.Join<string>(",",g.Select(i => i.Field<string>("Loc"))); 
             return t;
          }    
    
