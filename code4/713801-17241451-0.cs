    SqlConnection connRed = new SqlConnection();
    SqlConnection connBlue = new SqlConnection();
    
    if(radioButtonRed.Checked)
    {
        DataTable dtRed = new DataTable();
        SqlDataAdapter daRed = new SqlDataAdapter("select command", connRed);
        daRed.Fill(dtRed);
    
        dgv.DataSource = dtRed;
    }
    else
    {    
        DataTable dtBlue = new DataTable();
        SqlDataAdapter daBlue = new SqlDataAdapter("select command", connBlue);
        daBlue.Fill(dtBlue);
    
        dgv.DataSource = dtBlue;
    }
