    public virtual IMyIdentity GetCurrentUserIdentity(bool ignoreXyz)
    {
        if (_userProfile != null && _userProfile.IsAnonymous && (ignoreXyz || _userProfile.PointId > 0))
        {
            return new UserIdentity
                       {
                           Name = _userProfile.UserName,
                           IsAuthenticated = true,
                           AuthenticationType = UserIdentity.AUTHENTICATION_ANONYMOUS
                       };
        }
        else
        {
            return new UserIdentity
                       {
                           Name = HttpContext.Current.User.Identity.UserName,
                           IsAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated,
                           AuthenticationType = HttpContext.Current.User.Identity.AuthenticationType
                       };			                
        }
    }
