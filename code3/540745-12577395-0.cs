    SPServiceContext serviceContext = SPServiceContext.GetContext(site);
    UserProfileManager profileManager = new UserProfileManager(serviceContext);
    UserProfile profile = null;
    profile = profileManager.GetUserProfile(domainUserName);
    List<string> props = GetPropertiesFromSetting();
    foreach (string propName in props)
    {
       profile[propName].ProfileSubtypeProperty.IsUserEditable = false;
    }
