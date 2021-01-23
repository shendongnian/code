     public void fillComboBox()
        {
            comboBox1.DisplayMember = "FullName";
            comboBox1.Items.Add("Add employee");
            using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
            {
                myDatabaseConnection.Open();
        
                using (SqlCommand mySqlCommand = new SqlCommand("Select EmployeeID, LastName, FirstName, MiddleName from Employee", myDatabaseConnection))
                {
                    using (SqlDataReader sqlreader = mySqlCommand.ExecuteReader())
                    {
                        while (sqlreader.Read())
                        {
                            comboBox1.Items.Add(new Employee(sqlreader));
                        }
                    }
                }
            }
        }
