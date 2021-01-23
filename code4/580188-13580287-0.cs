    private bool TryGetPrincipal(string username, string password, out IPrincipal principal)
        {      string connectionString = ConfigurationManager.ConnectionStrings["WinBoutsConnectionString"].ConnectionString;    
            username = username.Trim();
            password = password.Trim();
            //only supporting SSO login atm
           // var valid = Membership.Provider.ValidateUser(username, password);
            serviceContext = new WinBoutsDataContext<DataAccess.Model.UserInfo>(connectionString);
            userRepository = new UserRepository(serviceContext);
            var valid = this.userRepository.ValidateAccount(username, password);
            
            if (valid)
            {
                // once the user is verified, assign it to an IPrincipal with the identity name and applicable roles
                principal = new GenericPrincipal(new GenericIdentity(username), System.Web.Security.Roles.GetRolesForUser(username));
                return true;
            }
            //user wasn't found, unauthorised
            principal = null;
            return false;
        }
