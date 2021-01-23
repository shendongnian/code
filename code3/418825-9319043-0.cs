    DataSet dataSet;
    SqlDataAdapter adapter;
    string connectionString = "my connection string";
    
    using (var connection = new SqlConnection(connectionString))
    {
        dataSet = new DataSet();
        connection.Open();
    
        adapter = new SqlDataAdapter("SELECT * FROM dbo.MyTable", connection);
        var commandBuilder = new SqlCommandBuilder(adapter);
    
        adapter.Fill(dataSet, "MyTable");
    
        dataGridView1.DataSource = dataSet.Tables["MyTable"];
    }
    
    //Whenever you update
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        if (adapter.Update(dataSet.Tables["MyTable"]) > 0)
            lblMessage.Text = "INFO: Record updated successfully!";
    }
