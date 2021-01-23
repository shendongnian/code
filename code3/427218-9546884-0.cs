    public static Models.User GetUser(this Controller controller)
        {
            string name = controller.User.Identity.Name;
            string alias = name.Substring(name.LastIndexOf('\\') + 1);
            string domain = name.Substring(0, name.IndexOf('\\') - 1);
            User user = User.ByAlias(alias);
            if (user == null)
            {
                user = new User();
                user.Name = controller.User.Identity.Name;
                user.Alias = alias;
                user.Domain = domain;
                user.Description = "Automatically registered";
                Guid userId = Models.User.Create(user, Guid.Empty);
                user = User.ByAlias(alias);
            }
            return user;
        }
