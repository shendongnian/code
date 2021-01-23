    public enum ActiveDirectoryObjectClass
    {
        Computer,
        User,
        Domain,
        Group,
    }
    public static class ActiveDirectorySearcher
    {
        public static string  GetCurrentDomainName()
        {
            string result;
            using (Domain domain = Domain.GetCurrentDomain())
            {
                result = domain.Name;
            }
            return result;
        }
        public static IEnumerable<T> Select<T>(
            ActiveDirectoryObjectClass activeDirectoryObjectClass,
            Func<DirectoryEntry, ActiveDirectoryObjectClass, bool> condition,
            Func<DirectoryEntry, T> selector
            )
        {
            List<T> list = new List<T>();
            using (Domain domain = Domain.GetCurrentDomain())
            using (DirectoryEntry root = domain.GetDirectoryEntry())
            {
                string filter = string.Format("(objectClass={0})", activeDirectoryObjectClass);
                using (DirectorySearcher searcher = new DirectorySearcher(filter))
                {
                    searcher.SearchRoot = root;
                    searcher.SearchScope = SearchScope.Subtree;
                    using (SearchResultCollection result = searcher.FindAll())
                    {
                        foreach (SearchResult item in result)
                        {
                            using (DirectoryEntry entry = item.GetDirectoryEntry())
                            {
                                if (condition(entry, activeDirectoryObjectClass))
                                {
                                    list.Add(selector(entry));
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }
    }
