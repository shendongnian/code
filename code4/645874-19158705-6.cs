    public class AuthCacheManager : AuthManager
        {
            public override TokenIdentity CurrentUser
            {
                get
                {
                    var authToken = HttpContext.Current.Request.Headers["AuthToken"];
                    if (authToken == null) return null;
    
                    if (HttpRuntime.Cache[authToken] != null)
                    {
                        return (TokenIdentity) HttpRuntime.Cache.Get(authToken);
                    }
                    
                    return base.CurrentUser;
                }
            }
    
            public int? CurrentUserID
            {
                get
                {
                    if (CurrentUser != null)
                    {
                        return CurrentUser.UserID;
                    }
                    return null;
                }
            }
    
            public override TokenIdentity Authenticate(
                ISocialUser socialUser, 
                DeviceType? deviceType = null, 
                string deviceRegistrationID = null)
            {
                if (socialUser == null) throw new ArgumentNullException("socialUser");
                var identity = base.Authenticate(socialUser, deviceType, deviceRegistrationID);
    
                HttpRuntime.Cache.Add(
                    identity.AuthToken,
                    identity,
                    null,
                    DateTime.Now.AddDays(7),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Default,
                    null);
    
                return identity;
            }
        }
