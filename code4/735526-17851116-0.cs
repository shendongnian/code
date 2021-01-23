    flowLayoutPanel1.Controls.Clear();
            using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
            {
                myDatabaseConnection.Open();
                string a = "SELECT TOP(10) EmpID, Name FROM EmpTable";
                using (SqlCommand SqlCommand = new SqlCommand(" "+ a +" ", myDatabaseConnection))
                {
                    int i = 0;
                    SqlDataReader DR1 = SqlCommand.ExecuteReader();
                    while (DR1.Read())
                    {
                        i++;
                        BookUserControl usercontrol = new BookUserControl();
                        usercontrol.Tag = i;
                        usercontrol.EmpID = DR1["EmpID"].ToString();
                        usercontrol.Name = (string)DR1["Name"];
                        flowLayoutPanel1.Controls.Add(usercontrol);
                    }
                }
            }
