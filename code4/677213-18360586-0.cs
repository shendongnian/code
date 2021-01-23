        public static IEnumerable<Principal> getAuthorizationGroups(UserPrincipal user)
        {
            PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
            List<Principal> ret = new List<Principal>();
            var iterGroup = groups.GetEnumerator();
            using (iterGroup)
            {
                while (iterGroup.MoveNext())
                {
                    try
                    {
                        Principal p = iterGroup.Current;
                        Console.WriteLine(p.Name);
                        ret.Add(p);
                    }
                    catch (NoMatchingPrincipalException pex)
                    {
                        continue;
                    }
                }
            }
            return ret;
        }
