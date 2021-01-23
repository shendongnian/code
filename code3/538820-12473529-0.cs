    string conn = WebConfigurationManager.ConnectionStrings["GraduatesConnectionString"].ToString();
    // Create connection object
    using(SqlConnection connection = new SqlConnection(conn))
	{
		string queryText = "INSERT INTO PersonalInfo(Id,Name,LastName,ContactNumber, Address,Gender, Date_Of_Birth) VALUES(@id,@name,@lastName,@contactNumber, @address,@gender, @date_Of_Birth)";
		using(SqlCommand command = new SqlCommand(queryText, connection))
		{
			try
			{
				// Open the connection.
				connection.Open();
				
				command.Parameters.AddWithValue("@id", this.txtID.Text);
				command.Parameters.AddWithValue("@name", this.txtName.Text);
				command.Parameters.AddWithValue("@lastName", this.txtLastName.Text);
				command.Parameters.AddWithValue("@contactNumber", this.txtContactNumber.Text);
				command.Parameters.AddWithValue("@address", this.txtAddress.Text);
				command.Parameters.AddWithValue("@gender",this.gender );
				command.Parameters.AddWithValue("@date_Of_Birth", this.txtDateofBirth.Text);
				command.ExecuteReader();
			}
			finally
			{	
				// Close the connection.
				if(connection.State != ConnectionState.Closed)
					connection.Close();
			}
		}
    }
    
