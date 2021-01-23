     class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.RowChanged += new DataRowChangeEventHandler(dt_RowChanged);
            dataTable.Rows.Add(1);
            dataTable.Rows.Add(2);
            dataTable.Rows.Add(3);
            Console.WriteLine("Total rows: {0}", dataTable.Rows.Count);
            foreach (DataRow item in dataTable.Rows)
            {
                Console.WriteLine(item["ID"]);
            }
            Console.Read();
        }
        private static void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                if (((int)e.Row["ID"]) == 2)
                {
                    e.Row.Delete();
                }
            }
        }
    }
