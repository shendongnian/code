    SqlConnection connRed = new SqlConnection();
    SqlConnection connBlue = new SqlConnection();
    DataTable dt = null;
    SqlDataAdapter da = null;
    
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
    dgv.DataBind();
