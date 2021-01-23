        public IEnumerable<User> GetUsers()
        {
            return ActiveDirectorySearcher.Select(
                ActiveDirectoryObjectClass.User,
                (entry, adObjectClass) => string.Compare(entry.SchemaClassName, adObjectClass.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0,
                _ => new User
                         {
                             Name = _.Name.Substring(3),
                             Domain = ActiveDirectorySearcher.GetCurrentDomainName(),
                         });
        }
