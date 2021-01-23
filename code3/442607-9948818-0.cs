    public class UserCollection : ICollection<User>
    {
        public User this[int index]
        {
            get
            {
                return this.FirstOrDefault(x => x.UserID == index);
            }
        }
    
        // all the other ICollection methods
    
    }
    
    public static ICollection<User> GetUser()
    {
        return new UserCollection
                   {
                       new User {UserID = 2},
                       new User {UserID = 4}
                   };
    }
