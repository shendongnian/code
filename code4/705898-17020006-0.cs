    public class DB
    {
        public static string constr = "Server=localhost;Database=University; Integrated Security=true;MultipleActiveResultSets=True;";
        public static string userTable = "Users", userPassword = "Passwd", 
        userName = "UserID", loginRole = "Role";
    }
    public class login
    {
       public int doLogin(string user, string pass)
       {
          string role="0";
          using (var conn = new SqlConnection(DB.constr) {
            using (var my_cm = conn.CreateCommand() {
             my_cm.CommandText = string.Format(
                 "select {0} from {1} where {2} = @username and {3} = @password",
                 DB.loginRole,
                 DB.userTable,
                 DB.userName,
                 DB.userPassword);
             my_cm.Parameters.AddWithValue("@username", user);
             mt_cm.Parameters.AddWithValue("@password", CodePass(user,pass));
             using (var dbread = my_cm.ExecuteReader()) {
               if (!dbread.Read()) {
                 return 0; // or something else if user not found
               }
               return int.Parse(dbRead[0].ToString());
             }
          }
        }
      }
  
      public string CodePass(string user, string pass)
      {
        System.Security.Cryptography.SHA1CryptoServiceProvider sha = 
              new SHA1CryptoServiceProvider();
        return System.Text.Encoding.ASCII.GetString(
          sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(user + pass)));
      }
    }
