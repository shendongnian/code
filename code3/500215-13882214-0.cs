        private static FieldUserValue GetUser(ClientContext clientContext, string userName)
        {
            var userValue = new FieldUserValue();
            var newUser = clientContext.Web.EnsureUser(userName);
            clientContext.Load(newUser);
            clientContext.ExecuteQuery();
            userValue.LookupId = newUser.Id;
            return userValue;
        }
