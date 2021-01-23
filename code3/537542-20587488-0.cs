        protected override void Seed(UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);
            if (!WebSecurity.UserExists("yardpenalty"))
                WebSecurity.CreateUserAndAccount(
                    "yardpenalty",
                    "password",
                    new
                    {
                        Email = "youremail@yahoo.com",
                        ImageUrl = "/Content/Avatars/yourname",
                        DateJoined = DateTime.Now
                    },
                    false);  
               //... rest of model.Builder stuff 
       }
