    public static string BuildCacheKey(HashSet<Permission> permissions)
    {
        var builder = new StringBuilder("permission_");
        foreach (var permission in permissions.OrderBy(p => p.Name))
        {
            builder.Append(permission.Name);
        }
        return builder.ToString();
    }
