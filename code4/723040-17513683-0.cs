    class Program
    {
        static void Main(string[] args)
        {
            // setup dummy DataTable
            var tbl = new DataTable();
            tbl.Columns.Add("id", typeof(Int32));
            tbl.Columns.Add("learningGroup", typeof(String));
            tbl.Columns.Add("tutor", typeof(String));
            
            tbl.Rows.Add(1, "", "");
            tbl.Rows.Add(1, "group 1", "sam");
            tbl.Rows.Add(2, "group 1", "john");
            tbl.Rows.Add(3, "group 2", "paul");
            tbl = Group(tbl);
            // print DataTable
            foreach (DataRow row in tbl.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item+"|");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
        // Group-Concat learningGroup and 
        // tutor copying to new DataTable
        static DataTable Group(DataTable tbl)
        {
            var groups = tbl.AsEnumerable()
                            .GroupBy(r => r.Field<Int32>("id"))
                            .Select(g => new {
                                                id = g.Key,
                                                learningGroup = string.Join(",", g.Select(s => s["learningGroup"])).TrimStart(','),
                                                tutor = string.Join(",", g.Select(s => s["tutor"])).TrimStart(','),
                                             });
            var newtbl = new DataTable();
            newtbl.Columns.Add("id", typeof(Int32));
            newtbl.Columns.Add("learningGroup", typeof(String));
            newtbl.Columns.Add("tutor", typeof(String));
            foreach (var g in groups)
            {
                newtbl.Rows.Add(g.id, g.learningGroup, g.tutor);
            }
            return newtbl;
        }
    }
