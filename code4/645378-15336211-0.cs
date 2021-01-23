    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
    
        SqlConnection con = new SqlConnection(strConnection);
        con.Open();
    
        string tableName = comboBox1.SelectedText;
    
        SqlCommand sqlCmd = new SqlCommand();
        sqlCmd.Connection = con;
        sqlCmd.CommandType = CommandType.Text;
        sqlCmd.CommandText = "Select * from " + tableName;
    
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
    
        DataTable dtRecord = new DataTable();
        sqlDataAdap.Fill(dtRecord);
        dgv.DataSource = dtRecord;
        con.Close();
    }
