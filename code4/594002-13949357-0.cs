    using(SqlConnection connection = new SqlConnection("YOUR CONNECTION STRING"))
    {
        try
        {
            using(SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT * FROM members where dID = @MyId";
                command.Connection = connection;
                // Set the SqlDbType to your corresponding type
                command.Parameters.Add("@MyId", SqlDbType.VarChar).Value = txtdID.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtID.Text = reader["ID"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtMobile.Text = reader["Mobile"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtdID.Text = reader["dID"].ToString();
                }
            }
        }
        finally
        {
            connection.Close();
        }
     }
