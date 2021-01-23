    public DataTable Select(String sqlQuery)
       {       
           con.Open();
           SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery,con);
           DataTable table = new DataTable();
           adapter.Fill(table);
           con.Close();
           return table;
       }
