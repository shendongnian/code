        static void Main(string[] args)
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("name", typeof(string));
            table.Rows.Add(new object[] { 1, "test" });
            var item = table.AsEnumerable().Select(row =>
               new  {
                   id = row.Field<string>("id"),
                   name = row.Field<string>("name")
               }).First();
            Console.WriteLine(item.name);
        }
