    public String Login(String userName, String password)
        {
            OleDbConnection connect = new OleDbConnection(connection);
            connect.Open();
            
            OleDbCommand command = new OleDbCommand("Select UID, firstName, lastName from login where userName=?  and password =?", connect);
            command.CommandType = CommandType.Text;
            
            //to avoid sql injection
            command.Parameters.Add(userName);
            command.Parameters.Add(password);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            DataSet NSNSet = new DataSet();
            adapter.Fill(NSNSet);
            if (NSNSet.Tables[0].Rows.Count == 0)
                return "Access denied";
            string username = NSNSet.Tables[0].Rows[0]["firstName"].ToString() + NSNSet.Tables[0].Rows[0]["lastName"].ToString();
            int userID = int.Parse(NSNSet.Tables[0].Rows[0]["UID"].ToString());
            return username + "," + userID;
        }
