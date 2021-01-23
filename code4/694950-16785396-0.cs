    using(SqlConnection cn = new SqlConnection("connection_string"))
    {
       cn.Open();
       using(SqlDataAdapter adapter = new SqlDataAdapter("selest * from table_name",cn))
       {
           DataTable table = new DataTable();
           adapter.Fill(table);
           foreach(DataRow row in table.Rows)
           {
               //get column data for a row using row["column_name"].ToString()
           }
       }
    }
