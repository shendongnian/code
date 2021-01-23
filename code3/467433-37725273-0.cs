    public static Task<IEnumerable<SomeUserModelClass>> GetUsers(//Whatever filters you want)
    {
        return Task.Run(() =>
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain);
            UserPrincipal principal = new UserPrincipal(context);
            principal.Enabled = true;
            PrincipalSearcher searcher = new PrincipalSearcher(principal);
            var users = searcher.FindAll().Cast<UserPrincipal>()
                .Where(x => x.SomeProperty... // Perform queries)
                .Select(x => new SomeUserModelClass
                {
                    userName = x.SamAccountName,
                    email = x.UserPrincipalName,
                    guid = x.Guid.Value
                }).OrderBy(x => x.userName).ToList();
            return users;
        });
    }
