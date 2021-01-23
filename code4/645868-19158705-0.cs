      public class AuthController : ApiController
        {
            public TokenIdentity Post(
                SocialNetwork socialNetwork,
                string socialUserID,
                [FromUri]string socialAuthToken,
                [FromUri]string deviceRegistrationID = null,
                [FromUri]DeviceType? deviceType = null)
            {
                var socialManager = new SocialManager();
    
                var user = socialManager.GetSocialUser(socialNetwork, socialUserID, socialAuthToken);
    
                var tokenIdentity = new AuthCacheManager()
                    .Authenticate(
                        user,
                        deviceType,
                        deviceRegistrationID);
    
                return tokenIdentity;
            }
        }
