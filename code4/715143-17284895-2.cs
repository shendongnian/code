		SqlDataReader SQl_Reader;
		string cmdString = "SELECT ShortName FROM departments WHERE ID = @ID;"
		SqlCommand SQl_Command2 = new SqlCommand(cmdString, SQl_Connection);
		SQl_Command2.Parameters.Add("@ID", department_Text.SelectedValue);
		SQl_Reader = SQl_Command.ExecuteReader();
		SQl_Reader.Read();
		string deptName = SQl_Reader["ShortName"].ToString();
		
		SQl_Reader.Close();
		SQl_Connection.Close();
		
