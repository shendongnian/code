    public class School
    {
        List<User> _users = new List<Users>();
        public IEnumerable<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users.Clean();
                _users.AddRange(value);
            }
        }
        public void AddUser(User user){
          _users.Add(user);
        }
    }
