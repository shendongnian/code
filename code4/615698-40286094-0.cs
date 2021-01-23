            var table = new DataTable();
            table.Columns.Add("span", typeof(TimeSpan));
            table.Rows.Add(new object[] { new TimeSpan(1, 2, 3) });
            table.Rows.Add(new object[] { new TimeSpan(4, 5, 6) });
            table.Columns.Add("asstring");
            table.Columns["asstring"].Expression = "Convert(span, 'System.String')";
