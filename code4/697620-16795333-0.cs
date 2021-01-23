            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            // Data for test
            table.Rows.Add("ABC", "Item_name", 6);
            table.Rows.Add("ABC", "Item_name", 6);
            table.Rows.Add("ABC2", "Item_name", 6);
            table.Rows.Add("ABC2", "Item_name", 6);
            table.Rows.Add("ABC2", "Item_name", 6);
            table.Rows.Add("ABC2", "Item_name", 6);
            // Query with Linq
            var query = from row in table.AsEnumerable()
                        group row by new {
                            name  = row.Field<String>("Name"),
                            title = row.Field<String>("Title")
                        } into GrpNameTitle
                        select new {
                            Name  = GrpNameTitle.Key.name + " (" + GrpNameTitle.Count() + ")", 
                            Title = GrpNameTitle.Key.title,
                            Quantity = GrpNameTitle.First().Field<int>("Quantity")
                        };
            foreach (var itm in query)
            {
                Console.WriteLine("{0}\t{1}", itm.Name, itm.Title);
            }
