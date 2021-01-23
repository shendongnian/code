    var copiedTable2 = table2.Copy(); // Copy table2 if you don't want it to be modified
    var items = from tb1 in table1.AsEnumerable()
                join tb2 in copiedTable2.AsEnumerable()
                on new
                {                
                    Name = tb1.Field<String>("Name"),
                    LastName = tb1.Field<String>("LastName"),
                } equals new
                {
                    Name=tb2.Field<String>("Name"),
                    LastName=tb2.Field<String>("LastName"),
                }
                into grp1
                from tb3 in grp1.DefaultIfEmpty()
                select new
                {
                    ID = tb1.Field<String>("ID"),
                    Name = tb1.Field<String>("Name") ,
                    LastName = tb1.Field<String>("LastName"),
                    Row = tb3 ?? table2.NewRow();
                };
     foreach(var item in items)
     {
         item.Row.SetField<String>("ID", item.ID);
         item.Row.SetField<String>("Name", item.Name);
         item.Row.SetField<String>("LastName", item.LastName);
     }
     var rows = items.Select(x => x.Row);
     // How to set the rows as a DataGridView's DataSource
     var result = table2.Clone();
     foreach(var row in rows)
     {
         result.Rows.Add(row.List.ToArray());
     }
     dataGridView.DataSource = result;
