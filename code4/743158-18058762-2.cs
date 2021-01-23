    public class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals(Role x, Role y)
        {
            return x.RoleID.Equals(y.RoleID);
        }
        public int GetHashCode(Role obj)
        {
            return obj.RoleID;
        }
    }
