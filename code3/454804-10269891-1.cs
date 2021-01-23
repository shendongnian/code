    public void AddNewUser(User u)
    {
       var query = "insert Users (name, password) values (@0, @1)";
       SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
            cmd.Parameters.AddWithValue("@0", u.UserName);
            cmd.Parameters.AddWithValue("@1", u.Password);
            }
    }
