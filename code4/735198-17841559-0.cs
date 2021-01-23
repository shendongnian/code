            var ds = new DataSet();
            var table1 = ds.Tables.Add("Table1");
            table1.Columns.Add("Expression", typeof (string));
            table1.Rows.Add("SN123");
            table1.Rows.Add("SN456");
            table1.Rows.Add("SN789");
            var table2 = ds.Tables.Add("Table2");
            table2.Columns.Add("Expression", typeof (string));
            table2.Rows.Add("SN000");
            table2.Rows.Add("SN456");
            table2.Rows.Add("SN999");
            var table1Rows = table1.AsEnumerable();
            var table2Rows = table2.AsEnumerable();
            var matches = table1Rows.Join(table2Rows, l => l["Expression"], r => r["Expression"], (l, r) => l["Expression"]);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
