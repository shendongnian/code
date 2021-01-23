      var dt = new System.Data.DataTable();
            dt.Columns.Add("MyDate", typeof(DateTime));
            dt.Rows.Add(new DateTime(2011,1,10));
            dt.Rows.Add(new DateTime(2011,2,10));
            int month = DateTime.ParseExact("January", "MMMM", CultureInfo.CurrentCulture).Month;
            var list = dt.AsEnumerable()
                         .Where(x => x.Field<DateTime>("MyDate").Month == month)
                         .Select(x => x.Field<DateTime>("MyDate")).ToList();
            foreach (var d in list)
            {
                Console.WriteLine(d);
            }  
