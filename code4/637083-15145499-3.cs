    public class CustomSimpleMembershipProvider
    {
        private readonly UsersContext _db = new UsersContext();
        public bool CreateUser(string username, string password, string firstName)
        {
            var userCreated = false;
            WebSecurity.CreateUserAndAccount(username, password);
            var userProfile = _db.UserProfiles.FirstOrDefault(u => u.UserName == username);
            // Check if user already exists
            if (userProfile != null)
            {
                var member = new Model.User { FirstName = firstName, UserProfile = userProfile };
                try
                {
                    _db.Users.Add(member);
                    _db.SaveChanges();
                    userCreated = true;
                }
                catch (Exception)
                {
                    //Add logging or throw whatever exceptions needed
                    throw;
                }
            }
            return userCreated;
        }
    }
