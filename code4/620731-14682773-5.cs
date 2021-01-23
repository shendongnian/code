        //assuming the source data has ID and Order properties
        private static DataTable CreateDataTable(IEnumerable<OrderData> source) {
          DataTable table = new DataTable();
          table.Columns.Add("ID", typeof(int));
          table.Columns.Add("Order", typeof(int));
          foreach (OrderData data in source) {
              table.Rows.Add(data.ID, data.Order);
          }
          return table;
        }
