    Gridview1_ObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e) {
       DataSet ds = get();
    
       Dictionary<string, List<DateTime>> dict = new Dictionary<string, List<DateTime>>(); 
    
       var rows = ds.Tables[0].AsEnumerable()
                              .Select(row => new { name = row.Field<string>("name"), RunDate = row.Field<DateTime>("RunDate") })
                              .GroupBy(r => r.name)
       foreach (var group in rows) {
          dict.Add(group.Key, group.ToList());
       }
       e.ReturnValue = dict;
    }
    
