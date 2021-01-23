    public static string PasswordHasher(string Password)
    {
    return FormsAuthentication.HashPasswordForStoringInConfigFile(Password,     
    System.Web.Configuration.FormsAuthPasswordFormat.SHA1);
    }
