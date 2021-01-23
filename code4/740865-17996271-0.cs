     public static class AccountManagementExtensions
        {
            public static String GetProperty(this Principal principal, String property)
            {
                var directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
                return directoryEntry != null && directoryEntry.Properties.Contains(property)
                           ? directoryEntry.Properties[property].Value.ToString()
                           : String.Empty;
            }
    
            public static String GetCompany(this Principal principal)
            {
                return principal.GetProperty("company");
            }
    
            public static String GetDepartment(this Principal principal)
            {
                return principal.GetProperty("department");
            }
        }
