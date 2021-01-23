      class Program
      {
        static void Main(string[] args)
        {
          DataTable dataTable = new DataTable();
          dataTable.Columns.Add().ColumnName = "First";
          dataTable.Columns.Add().ColumnName = "Last";
          var row = dataTable.NewRow();
          row["First"] = "hello";
          row["Last"] = "world";
          dataTable.Rows.Add(row);
    
          var query = dataTable.Rows.Cast<DataRow>()
            .Select(r => new
            {
              First = r["First"],
              Last = r["Last"]
            });
          foreach (var item in query)
            Console.WriteLine("{0} {1}", item.First, item.Last);
        }
      }
