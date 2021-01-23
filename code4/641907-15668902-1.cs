		 private UserAuth SetUserAuth(string userName)
		        {
		            // NOTE: We need a link to the database table containing our user details
		            string connStr = ConfigurationManager.ConnectionStrings["YOURCONNSTRNAME"].ConnectionString;
		            var connectionFactory = new OrmLiteConnectionFactory(connStr, SqlServerDialect.Provider);
		            // Create an Auth Repository
		            var userRep = new OrmLiteAuthRepository(connectionFactory);
		           
		            // Password not required. 
		            const string password = "NotRequired";
		            // Do we already have the user? IE In our Auth Repository
		            UserAuth userAuth = userRep.GetUserAuthByUserName(userName);
		            if (userAuth == null ){ //then we don't have them}
		            // If we don't then give them the role of guest
		            userAuth.Roles.Clear();
		            userAuth.Roles.Add("guest")
		            // NOTE: we are only allowing a single role here		       
		            // If we do then give them the role of user
		            // If they are one of our team then our administrator have already given them a role via the setRoles removeRoles api in ServiceStack
		           ...
		            // Now we re-authenticate out user
		            // NB We need userAuthEx to avoid clobbering our userAuth with the out param
		            // Don't you just hate out params?
		            // And we re-authenticate our reconstructed user
		            UserAuth userAuthEx;
		            var isAuth = userRep.TryAuthenticate(userName, password, out userAuthEx);
		            return userAuth;
		        }
