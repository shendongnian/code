        public bool IsUserInRole(string username, string roleName)
        {
            var repo = new UserRepository();
            return repo.Users.Any(u => u.UserName == username && u.UserRoles.Any(userrole => userrole.Role.RoleName == roleName));
        }
