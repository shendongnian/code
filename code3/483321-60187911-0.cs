    [DirectoryRdnPrefix("OU")]
    [DirectoryObjectClass("organizationalUnit")]
    public class OuPrincipal : GroupPrincipal
    { 
        public OuPrincipal(PrincipalContext pc) : base(pc)
        {
        }
        OuPrincipalSearchFilter searchFilter;
        public OuPrincipalSearchFilter AdvancedSearchFilter
        {
            get
            {
                if ( null == searchFilter )
                    searchFilter = new OuPrincipalSearchFilter(this);
                return searchFilter;
            }
        }
        public object[] GetAttribute(string attribute)
        {
            return (ExtensionGet(attribute));
        }
        [DirectoryProperty("st")]
        public string State
        {
            get
            {
                if (ExtensionGet("st").Length != 1)
                    return null;
                return (string)ExtensionGet("st")[0];
            }            
        }  
