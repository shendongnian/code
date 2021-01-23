    SqlConnection connRed = new SqlConnection();
    SqlConnection connBlue = new SqlConnection();
    DataTable dt;
    SqlDataAdapter da;
    
    if(radioButtonRed.Checked)
    {
        dt = new DataTable();
        da = new SqlDataAdapter("select command", connRed);   
    }
    else
    {    
        dt = new DataTable();
        da = new SqlDataAdapter("select command", connBlue);
    }
    
    da.Fill(dt);
    dgv.DataSource = dt;
