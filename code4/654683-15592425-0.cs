    using (SqlConnection myConnection = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT P.Id from dbo.Tb_Patient;";
        cmd.CommandType = CommandType.Text;
        cmd.Connection  = myConnection;
        myConnection.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
            {
                string nameValue = reader["P.Id"].ToString();
                MessageBox.Show("value is:",nameValue);
                txtid.Text = nameValue;
            }
            else {
                MessageBox.Show("Data is not retrieved");
            }
        reader.Close();
    }
