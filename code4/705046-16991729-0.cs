    using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
        {
            myDatabaseConnection.Open();
            using (SqlCommand SqlCommand = new SqlCommand("Select ID, LastName from Employee", myDatabaseConnection))
            {
                SqlDataReader dr = SqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    int lastNameLength = dr["LastName"].Length;
                    int idLength = dr["ID"].Length;
                    int numberOfSpaces = 30 - lastNameLength - idLength;
                    string spaces = string.Empty;
                    for (int i = 0; i < numberOfSpaces; i++)
                    {
                        spaces = spaces + " "; 
                    }                    
                    listBox1.Items.Add((string)dr["LastName"] + spaces + dr["ID"]);
                }
            }
        }
