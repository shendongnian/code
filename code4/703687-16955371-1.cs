        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Value", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add(null, "a");
            table.Rows.Add(50, "a");
            table.Rows.Add(10, "a");
            table.Rows.Add(21, "b");
            table.Rows.Add(100, "b");
            return table;
        }
        static void Main(string[] args)
        {
            DataTable dt =GetTable();
            var str = dt.Compute("Sum(Value)", "Name='a' and Value is not null");
        }
