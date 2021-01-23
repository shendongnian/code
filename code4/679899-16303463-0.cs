    public class UserGroupComparer : IEqualityComparer<UserGroup>
    {
        public bool Equals(UserGroup x, UserGroup y)
        {
            return x.Group == y.Group && x.User == y.User;
        }
        public int GetHashCode(UserGroup obj)
        {
            return 37 * obj.Group.GetHashCode() + 19 * obj.User.GetHashCode();
        }
    }
