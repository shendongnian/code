        public User GetUser(string userNumber) {
            using(var conn = GetOpenConnection()) {
                return conn.Query<User>(@"
        select [some columns here]
        from Users where User_No = @userNumber",
                new {userNumber}).FirstOrDefault()
            }
        }
