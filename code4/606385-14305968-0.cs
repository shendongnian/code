    using ActiveDs;
    using BdsSoft.DirectoryServices.Linq;
    using System.Linq.Expressions;
    using System.DirectoryServices;
    
    [DirectorySchema( "user", typeof( IADsUser ) )]
    class User
    {
        public string Name { get; set; }
    
        public string sAMAccountName { get; set; }
    
        public string objectCategory { get; set; }
    
        public string mail { get; set; }
    
        public string Description { get; set; }
    
        [DirectoryAttribute( "PasswordLastChanged", DirectoryAttributeType.ActiveDs )]
        public DateTime PasswordLastSet { get; set; }
    
        [DirectoryAttribute("distinguishedName")]
        public string Dn { get; set; }
    
        [DirectoryAttribute("memberOf")]
        public string[] Groups { get; set; }
    
    }
