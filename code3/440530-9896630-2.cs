    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override int GetHashCode() { return this.Id.GetHashCode(); }
    }
    
    public static string BuildCacheKey(HashSet<Permission> permissions)
    {
        var hashCode = GetHashCode(permissions);
        return string.Format(CultureInfo.InvariantCulture, "permission_{0}", hashCode);
    }
    
    private static int GetHashCode(IEnumerable<Permission> permissions)
    {
        unchecked
        {
            var hash = 17;
            foreach (var permission in permissions.OrderBy(p => p.Id))
            {
                hash = hash * 23 + permission.GetHashCode();
            }
    
            return hash;
        }
    }
