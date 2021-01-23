    User user=null;
    if (reader.Read())
    {
            int UserID = Convert.ToInt32(reader["UserID"]);
            int IsAdmin = Convert.ToInt32(reader["IsAdmin"]);
            int IsActivated = Convert.ToInt32(reader["IsActivated"]);
            string Nickname = reader["Nickname"].ToString();
            string FirstName = reader["FirstName"].ToString();
            string LastName = reader["LastName"].ToString();
            string Email = reader["Email"].ToString();
            string Password = reader["Password"].ToString();
            string DateRegistered = reader["DateRegistered"].ToString();
            user = new User(UserID, IsAdmin, IsActivated, null, Nickname, FirstName, 
    }
    else 
    {
      // handle error no user
    }
    if (reader.Read())
    {
       // handle more than one user error
    }
    // other stuff close connect and reader etc.
    return user;
