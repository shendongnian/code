    public class UserRepository : IUserRepository
    {
        public IEnumerable<IUser> ShowAllUsers()
        {
            ...
            while (reader.Read())
            {
                 yield return new User
                 {
                     ...
                 };
            }
        }
    }
