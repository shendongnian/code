        public string[] Groups
        {
            get { return UserPrincipal.Current.GetAuthorizationGroups()
                                              .Select(e => e.SamAccountName)
                                              .ToArray(); }
        }
