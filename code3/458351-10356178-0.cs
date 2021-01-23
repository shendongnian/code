    private void button1_Click(object sender, EventArgs e)
    {
    	SqlConnection connection = new SqlConnection();
    	connection.ConnectionString = (@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\John\Documents\Setup.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True;");
    
    	SqlCommand command = new SqlCommand();
    	command.Connection = connection;
    	command.CommandText = "INSERT INTO dbo.MyTable  (userName, password) VALUES (@userName, @passWord)";
    	command.Parameters.AddWithValue("@userName", textBox1.Text);
    	command.Parameters.AddWithValue("@passWord", textBox2.Text);
    
    	try
    	{
    		connection.Open();
    		int rowsAffected = command.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    		//handle exception
    	}
    	finally
    	{
    		connection.Close();
    	}
    }
