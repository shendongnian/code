    private void btnRunSQL_click()
    {
        string strConnStr = tbConnStr.Text; // connection string from textbox
        string strSQL = tbSql.Text;         // query from textbox
    
        using(SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strConnStr))
        {
            using(SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter))
            {
                // edited after comment of  Jon Senchyna
                dtData.Clear();
                dataAdapter.Fill(dtData);
            }
         }
    }
