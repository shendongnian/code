    public String Login(String userName, String password)
        {
            OleDbConnection connect = new OleDbConnection(connection);
            connect.Open();
            OleDbCommand command = new OleDbCommand("Select UID, firstName, lastName from login where userName=?  and password =?", connect);
            command.CommandType = CommandType.Text;
            //to avoid sql injection
            command.Parameters.Add(userName);
            command.Parameters.Add(password);
            OleDbDataReader reader=command.ExecuteReader();
            if (reader.Read())
            {
                //that means there's at least one row
                string username = reader["firstName"] + " " + reader["lastName"];
                int userID = int.Parse(reader["UID"].ToString());
                return username + "," + userID;
            }
            else
            {
                //no combination username-password found
                return "Access denied";
            }
        }
