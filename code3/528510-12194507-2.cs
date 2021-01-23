        public User GetUser(string userNumber) {
            using(var conn = GetOpenConnection()) {
                return conn.Query<User>("SP_SelectUser",
                new {User_No = userNumber}, // <=== parameters made simple
                commandType: CommandType.StoredProcedure).FirstOrDefault()
            }
        }
    or with LINQ-to-SQL (EF is very similar):
        public User GetUser(string userNumber) {
            using(var db = GetDataContext()) {
                return db.Users.FirstOrDefault(u => u.User_No == userNumber);
            }
         }
