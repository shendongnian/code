    private void btnRunSQL_click()
    {
            string strConnStr = tbConnStr.Text; // connection string from textbox
            string strSQL = tbSql.Text;         // query from textbox
    
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strConnStr))
            {
               using(SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter))
               {
                   // clean memory
                   // dtData DataTable and BindingSource bs are declared in main form class
                   dtData = new DataTable(); 
                   bs = new BindingSource(); 
    
                   dataAdapter.Fill(dtData);
              }
          }
     }
