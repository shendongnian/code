    using (var session = documentStore.OpenSession())
    {
        var nonContractEmployees = session.Query<User>()
            .ToList()
            .Where(x => x.Roles.Contains(
                new Role {Type = UserType.Contract},
                new RoleComparer()));                        
    }
    public class RoleComparer : IEqualityComparer<Role>
    {
        public bool Equals(Role x, Role y)
        {
            return
                x == null && y == null ||
                x != null &&
                y != null &&
                x.Type == y.Type;
        }
        public int GetHashCode(Role obj)
        {
            return
                obj == null
                    ? 0
                    : obj.Type.GetHashCode();
        }
    }
