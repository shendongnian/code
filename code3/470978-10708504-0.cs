        private static void Main(string[] args)
        {
            var dt = getdt();
            var output = dt
                .Rows
                .Cast<DataRow>()
                .ToList();
            // or a CSV line
            var csv = dt
                .Rows
                .Cast<DataRow>()
                .Aggregate(new StringBuilder(), (sb, dr) => sb.AppendFormat(",{0}", dr[0]))
                .Remove(0, 1);
            Console.WriteLine(csv);
            Console.ReadLine();
        }
        private static DataTable getdt()
        {
            var dc = new DataColumn("column1");
            var dt = new DataTable("table1");
            dt.Columns.Add(dc);
            Enumerable.Range(0, 10)
                .AsParallel()
                .Select(i => string.Format("row {0}", i))
                .ToList()
                .ForEach(s =>
                {
                    var dr = dt.NewRow();
                    dr[dc] = s;
                    dt.Rows.Add(dr);
                });
            return dt;
        }
