    [DirectoryObjectClass("group")]
    [DirectoryRdnPrefix("CN")]
    public class GroupPrincipalsEx : GroupPrincipal
    {
        public GroupPrincipalsEx(PrincipalContext context) : base(context) { }
    
        public GroupPrincipalsEx(PrincipalContext context, string samAccountName)
            : base(context, samAccountName)
        {
        }
    
        [DirectoryProperty("mail")]
        public string EmailAddress
        {
            get
            {
                if (ExtensionGet("mail").Length != 1)
                    return null;
    
                return (string)ExtensionGet("mail")[0];
    
            }
            set { this.ExtensionSet("mail", value); }
        }
    }
