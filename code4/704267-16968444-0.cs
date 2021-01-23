    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("Person")]
    public class UserPrincipalEx : UserPrincipal
    {
        // Implement the constructor using the base class constructor. 
        public UserPrincipalEx(PrincipalContext context) : base(context)
        { }
        // Implement the constructor with initialization parameters.    
        public UserPrincipalEx(PrincipalContext context,
                             string samAccountName,
                             string password,
                             bool enabled) : base(context, samAccountName, password, enabled)
        {} 
        // Create the "TermSrvProfilePath" property.    
        [DirectoryProperty("msTSProfilePath")]
        public string TermSrvProfilePath
        {
            get
            {
                if (ExtensionGet("msTSProfilePath").Length != 1)
                    return string.Empty;
                return (string)ExtensionGet("msTSProfilePath")[0];
            }
            set { ExtensionSet("msTSProfilePath", value); }
        }
    }
    
