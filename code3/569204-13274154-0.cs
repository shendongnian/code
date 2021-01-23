class Program
    {
        static void Main(string[] args) {
            DataTable tbl = new DataTable();
            DataColumn col = new DataColumn("Blah", typeof(double));
            tbl.Columns.Add(col);
            DataRow row = tbl.NewRow();
            row["Blah"] = DBNull.Value;
            Console.WriteLine("Result: " + row["Blah"].ToString());
            Console.ReadKey();
        }
    }
