     public abstract class AuthManager
        {
            public virtual TokenIdentity CurrentUser
            {
                get
                {
                    var authToken = HttpContext.Current.Request.Headers["AuthToken"];
                    if (authToken == null) return null;
    
                    using (var usersRepo = new UsersRepository())
                    {
                        var user = usersRepo.GetUserByToken(authToken);
    
                        if (user == null) return null;
    
                        return new TokenIdentity
                        {
                            AuthToken = user.AuthToken,
                            SocialUser = user,
                            UserID = user.ID
                        };
                    }
                }
            }
    
            public virtual TokenIdentity Authenticate(
                ISocialUser socialUser, 
                DeviceType? deviceType = null, 
                string deviceRegistrationID = null)
            {
                using (var usersRepo = new UsersRepository())
                {
                    var user = usersRepo.GetUserBySocialID(socialUser.SocialUserID, socialUser.SocialNetwork);
    
                    user = (user ?? new User()).CopyFrom(socialUser);
    
                    user.AuthToken = System.Guid.NewGuid().ToString();
    
                    if (user.ID == default(int))
                    {
                        usersRepo.Add(user);
                    }
    
                    usersRepo.SaveChanges();
                    
                    return new TokenIdentity
                    {
                        AuthToken = user.AuthToken,
                        SocialUser = user,
                        UserID = user.ID
                    };
                }
            }
        }
