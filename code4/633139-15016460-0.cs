    DataSet objDataSet = new DataSet();
    SqlConnection objConn = new SqlConnection();
    
    SqlCommand objComm = new SqlCommand("SELECT COUNT(*) FROM table", objConn);
    
    SqlDataAdapter objDataAdapter = new SqlDataAdapter(objComm);
    
    if (objConn.State == ConnectionState.Closed)
    {
    	objConn.Open();
    }
    
    objDataAdapter.Fill(objDataSet, strTable);
    
    dataGridView1.DataSource = objDataSet;
