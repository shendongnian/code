		using (OleDbConnection connName = new OleDbConnection(strCon))
        {
            String sqlName = "SELECT forename, Surname FROM customer WHERE customerID = @CustomerID";
            // Create a command to use to call the database.
            using (OleDbCommand commandname = new OleDbCommand(sqlName, connName))
			{
                    
				//Check the input is valid
				int customerID = 0;
                if (!int.TryParse(txtCustomerID.Text, out customerID))
                {
                    txtName.Text = "Customer ID Text box is not an integer";
                    return;
                }
                connName.Open();
                // Add the parameter to the command
                commandname.Parameters.Add("@CustomerID", OleDbType.Integer).Value = customerID;
                // Create a reader containing the results
				using (OleDbDataReader readerName = commandname.ExecuteReader())
				{
					readerName.Read(); // Advance to the first row.
					txtName.Text = readerName[0].ToString();
				}
				connName.Close();                 
			}
		}
