        private IList<User> GetUsersFromDataTable(DataTable usersTable) 
        { 
            IList<User> users = new List<User>(); 
            foreach (DataRow row in usersTable.Rows) 
            { 
                User user = new User(); 
                user.UserID = (int)row["UserID"]; 
                user.Password = (string)row["Password"]; 
                user.Username = (string)row["Username"]; 
                users.Add(user);
            } 
            return users; 
        }
