     DataTable Table = new DataTable("TestTable");
     using(SqlCommand _cmd = new SqlCommand(queryStatement, _con))
        {        
           SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
           _con.Open();
           _dap.Fill(Table);
           _con.Close();
    
          }
     Console.WriteLine(Table.Rows.Count);  
     foreach (DataRow dataRow in Table.Rows)
          {
           foreach (var item in dataRow.ItemArray)
           {
            Console.WriteLine(item);
           }
          }
