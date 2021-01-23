    bool IsInGroup(string user, string group)
    {
        using (var identity = new WindowsIdentity(user))
        {
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(group);
        }
    }
