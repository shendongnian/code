    protected void Button2_Click(object sender, EventArgs e)
            {
                    string connectionString = ConfigurationManager.ConnectionStrings["sqlstudentConnectionString"].ConnectionString;
                    string command = "INSERT INTO [student] (studentID, studentFirstName, studentLastName) VALUES (@studID, @FName, '" + @LName + "')";
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
    
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = command;
                    cmd.Parameters.AddParameter.WithValue("@studID",txtStudentID);
                    cmd.Parameters.AddParameter.WithValue("@FName",txtFName);
                    cmd.Parameters.AddParameter.WithValue("@LName",txtLName);
                    cmd.Connection = sqlConnection;
    
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
    
                    TextID.Text = "";
                    TextFirstName.Text = "";
                    TextLastName.Text = "";
                    populateDataGrid();
            }
