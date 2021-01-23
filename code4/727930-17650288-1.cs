            var dt=new DataTable();
            dt.Columns.Add("A", typeof (string));
            dt.Columns.Add("B", typeof (string));
            dt.Columns.Add("C", typeof (int));
            dt.Rows.Add("John", "Doe", 23);
            dt.Rows.Add("John", "Doe", 24);
            dt.Rows.Add("John", "Doe", 25);
            var result = from row in dt.AsEnumerable()
                         group row by new {A=row.Field<string>("A"), B=row.Field<string>("B")} into grp
                         select new
                         {
                             CustomerName = grp.Key,
                             Items = String.Join(",",grp.Select(r=>r.Field<int>("C")))
                         };
            foreach (var t in result)
                Console.WriteLine(t.CustomerName + " " + t.Items);
