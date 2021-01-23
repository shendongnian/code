    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["sqlstudentConnectionString"].ConnectionString;
        string command = @"INSERT INTO [student] (
            studentID, studentFirstName, studentLastName
        ) VALUES (
            @studID, @FName, @LName
        )";
        
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = command;
            cmd.Parameters.AddWithValue("@studID", TextID.Text);
            cmd.Parameters.AddWithValue("@FName", TextFirstName.Text);
            cmd.Parameters.AddWithValue("@LName", TextLastName.Text);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
 
        TextID.Text = "";
        TextFirstName.Text = "";
        TextLastName.Text = "";
        populateDataGrid();
    }
