    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    using System.Net.NetworkInformation;
    using System.Security.Principal;
     
    namespace Alpha.Code
    {
        public static class SecurityExtensions
        {
            public static bool IsDomainAdmin (this WindowsIdentity identity)
            {
                Domain d = Domain.GetDomain(new
                    DirectoryContext(DirectoryContextType.Domain, getDomainName()));
                using (DirectoryEntry de = d.GetDirectoryEntry())
                {
                    byte[] bdomSid = (byte[])de.Properties["objectSid"].Value;
                    string sdomainSid = sIDtoString(bdomSid);
                    WindowsPrincipal wp = new WindowsPrincipal(identity);
                    SecurityIdentifier dsid = new SecurityIdentifier(sdomainSid);
                    SecurityIdentifier dasid = new SecurityIdentifier(
                        WellKnownSidType.AccountDomainAdminsSid, dsid);
                    return wp.IsInRole(dasid);
                }
            }
     
            public static string getDomainName()
            {
                return IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
     
            public static string sIDtoString(byte[] sidBinary)
            {
                SecurityIdentifier sid = new SecurityIdentifier(sidBinary, 0);
                return sid.ToString();
            }
        }
    }
