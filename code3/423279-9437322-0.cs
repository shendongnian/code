    // Setting up DB stuff.
            string s_ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data " +
                "Source=|DataDirectory|\\CloseoutApp.accdb";
            string s_Query = "SELECT UserID, UserName, UserTitle, UserArea FROM Users " +
                "ORDER BY UserID;";
            ObservableCollection<User> userList = new ObservableCollection<User>();
            using (OleDbConnection AccessConn = new OleDbConnection(s_ConnString))
            {
                using (OleDbCommand AccessCmd = AccessConn.CreateCommand())
                {
                    AccessCmd.CommandText = s_Query;
                    try
                    {
                        AccessConn.Open();
                        OleDbDataReader rdr = AccessCmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            User newUser = new User();
                            newUser.UserID = rdr.GetInt32(0);
                            newUser.UserName = rdr.GetString(1);
                            newUser.UserTitle = rdr.GetString(2);
                            newUser.UserArea = rdr.GetString(3);
                            userList.Add(newUser);
                        }
                        rdr.Close();
                    }
                    catch(Exception ex)
                    {
                        //do something with ex
                    }
                }
            }
            // Add users to the ListBox.
            foreach (User u in userList)
            {
                lb_Users.Items.Add(u.UserName);
            }
