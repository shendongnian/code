    private void btnRunSQL_click()
    {
            string strConnStr = tbConnStr.Text; // connection string from textbox
            string strSQL = tbSql.Text;         // query from textbox
    
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strConnStr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
    
    
            dataAdapter.Fill(dtData);
     }
