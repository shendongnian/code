    using (SqlConnection sqlConnection = new SqlConnection("connstring"))
    {
        SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Doctor", sqlConnection);
        sqlConnection.Open()
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
        while (sqlReader.Read())
        {
            cbDoctor.Items.Add(sqlReader["name"].ToString());
        }
        sqlReader.Close()
    }
