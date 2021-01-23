    var query =dt.AsEnumerable().GroupBy(item => item.Field<string>("ID"))
          .Select(g => {
             dynamic t = new System.Dynamic.ExpandoObject();
             var t1 = dostuff(g,"Status");
             if (t1 != null)
              ((IDictionary<System.String, System.Object>)t)["Status"] = t1;
             t1 = dostuff(g,"Disc");
             if (t1 != null)
              ((IDictionary<System.String, System.Object>)t)["Disc"] = t1;
             t.ID = g.Key;
             t.Loc = String.Join<string>(",",g.Select(i => i.Field<string>("Loc"))); 
             return t;
          }    
    
