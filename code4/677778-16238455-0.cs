    private void btnRunSQL_click()
    {
            string strConnStr = tbConnStr.Text; // connection string from textbox
            string strSQL = tbSql.Text;         // query from textbox
    
            using(var dataAdapter = new SqlDataAdapter(strSQL, strConnStr))
            using(var commandBuilder = new SqlCommandBuilder(dataAdapter)) {
                 dtData = new DataTable(); 
                 bs = new BindingSource(); 
    
                 dataAdapter.Fill(dtData);
            }
    }
