     DataTable tbl = new DataTable();
     foreach (DataRow row in tbl.Rows)
     {
       foreach (DataColumn col in tbl.Columns)
       {
         object cellData = row[col];
       }
     }
