    using (var connection = new SqlConnection(dbfile))
    using(var command = connection.CreateCommand())
    {
    	connection.Open();
    	
    	command.CommandText = "Insert into Temptranstion (CustomerID, ProductName,Quantity,Price,DateTime ) Values (@CustomerID,@ProductName,@Quantity,@Price,@DateTime)";
    	command.Parameters.AddWithValue ("@CustomerID ",comboBox1.SelectedValue);
    	command.Parameters.AddWithValue ("@ProductName",textBox6.Text);
    	command.Parameters.AddWithValue ("@Quantity",textBox7.Text);
    	command.Parameters.AddWithValue ("@Price",textBox8.Text);
    	command.Parameters.AddWithValue ("@DateTime",DateTime.Now);
    	command.ExecuteNonQuery();
    }
