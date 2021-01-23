    using System.Security.Principal;
    namespace yourns
    {
    public class UserEnvTools
    {
        static  bool IsLocalAdmin()
        {
            var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return prin != null && (prin.IsInRole(localAdmins));
        } 
         
        static bool IsDomainAdmin()
        {
            var domainAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, 
                                                      WindowsIdentity.GetCurrent().User.AccountDomainSid);
            var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return prin != null && (prin.IsInRole(domainAdmins));
        }
    }
    }
