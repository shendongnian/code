        using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
        {
            myDatabaseConnection.Open();
            using (SqlCommand SqlCommand = new SqlCommand("Select LastName from Student", myDatabaseConnection))
            using (SqlDataAdapter da = new SqlDataAdapter(SqlCommand))
            {
                int i = 0;
                SqlDataReader DR1 = SqlCommand.ExecuteReader();
                while (DR1.Read())
                {
                    i++;
                    UserControl2 userconrol = new UserControl2();
                    userconrol.Tag = i;
                    userconrol.LastName = (string)DR1["LastName"];
                    flowLayoutPanel1.Controls.Add(userconrol);
                }
            }
        }
