        public int IsInRole()
        {
            int defaultValue = (int)UserRole.Default;
            var names = Enum.GetNames(typeof (UserRole));
            foreach (var name in names)
            {
                if(User.IsInRole(name))
                {
                    defaultValue = (int)((UserRole)Enum.Parse(typeof(UserRole), name));
                    break;
                }
            }
            return defaultValue;
        }
    public enum UserRole
    {
        Super = 30,
        Admin = 20,
        Guest = 10,
        Default = 5
    }
