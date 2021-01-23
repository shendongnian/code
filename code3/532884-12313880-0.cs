            string filePath = @"e:\temp\test.csv";
            string delimiter = ",";
            #region init DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("a", typeof(string)));
            dt.Columns.Add(new DataColumn("b", typeof(string)));
            dt.Columns.Add(new DataColumn("c", typeof(string)));
            dt.Columns.Add(new DataColumn("d", typeof(string)));
            dt.Columns.Add(new DataColumn("e", typeof(string)));
            dt.Columns.Add(new DataColumn("f", typeof(string)));
            dt.Columns.Add(new DataColumn("g", typeof(string)));
            dt.Columns.Add(new DataColumn("h", typeof(string)));
            dt.Columns.Add(new DataColumn("i", typeof(string)));
            dt.Columns.Add(new DataColumn("j", typeof(string)));
            dt.Columns.Add(new DataColumn("k", typeof(string)));
            dt.Columns.Add(new DataColumn("l", typeof(string)));
            dt.Columns.Add(new DataColumn("m", typeof(string)));
            dt.Columns.Add(new DataColumn("n", typeof(string)));
            dt.Columns.Add(new DataColumn("o", typeof(string)));
            dt.Columns.Add(new DataColumn("p", typeof(string)));
            for (int i = 0; i < 100000; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = "test" + i + " " + j;
                }
                dt.Rows.Add(dr);
            }
            #endregion
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    sb.Append(string.Join(delimiter, dr[col].ToString()));
                }
                sb.AppendLine();
            }
            File.WriteAllText(filePath, sb.ToString());
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
