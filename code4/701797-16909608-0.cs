    using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
            {
                myDatabaseConnection.Open();
                using (SqlCommand SqlCommand = new SqlCommand("Select LastName from Employee", myDatabaseConnection))
                using (SqlDataAdapter da = new SqlDataAdapter(SqlCommand))
                {
                    List<string> list1 = new List<string>();
                    SqlDataReader DR1 = SqlCommand.ExecuteReader();
                    while (DR1.Read())
                    {
                        list1.Add((string)DR1["LastName"]);
                    }
                    int i = 0;
                    foreach (string LastName in list1)
                    {
                        i++;
                        UserControl2 userconrol = new UserControl2();
                        userconrol.Tag = i;
                        userconrol.LastName = LastName;
                        flowLayoutPanel1.Controls.Add(userconrol);
                    }
                }
            }
