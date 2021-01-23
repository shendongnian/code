        public override string[] GetRolesForUser(string username)
        {
            // Create unique cache key for the user
            string key = String.Concat(username, ":", base.ApplicationName);
            string[] roles = HttpRuntime.Cache[key] as string[];
            if (roles != null)
            {
                roles = base.GetRolesForUser(username);
                HttpRuntine.Cache.Insert(key, roles.ToArray(), ...);
            }
        }
