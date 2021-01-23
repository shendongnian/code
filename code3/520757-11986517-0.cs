     String connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
     SqlConnection con = new Sqlconnection(connectionString);
                String insertSql = "INSERT INTO tbl_UserProfiles VALUES(@UserID, @FirstName, @LastName, @YearOfBirth, @Country)";
                SqlCommand myCommand = new SqlCommand(insertSql, con);
                myCommand.Parameters.AddWithValue("@UserID", newUserGuid);
                myCommand.Parameters.AddWithValue("@FirstName", FirstNameTB.Text);
                myCommand.Parameters.AddWithValue("@LastName", LastNameTB.Text);
                myCommand.Parameters.AddWithValue("@YearOfBirth", YearDDL.SelectedItem.Text);
                myCommand.Parameters.AddWithValue("@Country", CountryDDL.SelectedItem.Text);
                try
                {
                    con.Open();
                    myCommand.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
