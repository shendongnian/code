            DataTable table = new DataTable();
            table.Columns.Add("col1");
            table.Columns.Add("col2");
            table.Columns.Add("col3");
            var lines = File.ReadAllLines(@"Data.txt").ToList();
            lines.ForEach(line => table.Rows.Add(line.Split((char)9) ));
