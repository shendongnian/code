                SqlConnection myConnection = new SqlConnection(@"Server = (Local); Integrated Security = True;" + "Database = insertDataBaseName"); // Assuming (Local)
				myConnection.Open();
				SqlCommand myCommand = myConnection.CreateCommand();
				myCommand.CommandText = ("SELECT UserName, Password,from Login"); // Where Login is your table . UserName and Password Columns
				SqlDataReader myReader = myCommand.ExecuteReader();
				bool login = false;
				while (myReader.Read())
				{
					if (userNameBox.Text.CompareTo(myReader["UserName"].ToString()) == 0 && passwordBox.Text.CompareTo(myReader["Password"].ToString()) == 0) // A little messy but does the job to compare your infos assuming your using a textbox for username and password
					{
						login = true;
					}
				}
				if (login)
				{
			              //Your in.
				}
				else
				{
					MessageBox.Show("Invalid UserName or Password", "Access Denied"); // Error message
				}
                     myReader.Close(); 
                     myConnection.Close(); // Just close everything
