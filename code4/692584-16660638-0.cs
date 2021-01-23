        public string[] Groups
        {
            get { return UserPrincipal.Current.GetGroups()
                                              .Select(e => e.SamAccountName)
                                              .ToArray(); }
        }
