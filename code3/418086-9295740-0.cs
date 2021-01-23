    //string sqlStr2 = "SELECT Conference_Name, Year FROM ....";
    //SqlDataAdapter dAdapt2 = new SqlDataAdapter(sqlStr2, cnStr);
    //DataSet dataSet2 = new DataSet();
    //dAdapt2.Fill(dataSet2);
    form load 
    { 
       call BindData();
    } //this is sudu code.. 
    private void BindData()
    {
        DataSet dtSet = new DataSet();
        using (connection = new SqlConnection(connectionString))
        {
            command = new SqlCommand(sql, connection);              
            SqlDataAdapter adapter = new SqlDataAdapter();          
            connection.Open();
            adapter.SelectCommand = command;
            adapter.Fill(dtSet, "Customers");
            listBox1.DataContext = dtSet;
        }
    
    }
