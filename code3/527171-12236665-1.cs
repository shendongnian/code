    using System;
    using System.DirectoryServices.ActiveDirectory;
    using System.Security.Principal
    namespace xxxxx
      {
      public class UserEnvTools
         {
        public static bool IsDomainAdmin()
        {   //returns TRUE for a machine that is on a workgroup So consider GetDomain methods based on scenario 
            if (WindowsIdentity.GetCurrent().User.AccountDomainSid == null)
                return false;
            var domainAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid,
                                                      WindowsIdentity.GetCurrent().User.AccountDomainSid);
            var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return prin != null && (prin.IsInRole(domainAdmins));
        }
        public static bool IsDomainUser()
        {
            //returns TRUE for a machine that is on a workgroup So consider GetDomain methods based on scenario 
            if (WindowsIdentity.GetCurrent().User.AccountDomainSid == null)
                return false;
            var domainUsers = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid,
                                                    WindowsIdentity.GetCurrent().User.AccountDomainSid);
            var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return prin != null && (prin.IsInRole(domainUsers));
        }
    public static bool IsLocalAdmin()
    {
    var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
    var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
    return prin != null && (prin.IsInRole(localAdmins));
    }
        public static bool IsLocalUser()
        {
            var localUsers = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
            var prin = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return prin != null && (prin.IsInRole(localUsers));
        }
        // Current security context applies  
        public static Domain GetCurrentUserDomain()
        {
            try
            {
                return System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain();
            }
            // It may be better not to ctach such errors?
            catch (ActiveDirectoryOperationException) // no Controller/AD Forest can not be contacted
            {return null;}
            catch (ActiveDirectoryObjectNotFoundException) // The USers Domain is not known to the controller
            {return null;}
        }
        public static Domain GetCurrentMachineDomain()
        {
            try
            {
                return System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain();
            }
            // It may be better not to ctach such errors?
            catch (ActiveDirectoryOperationException) // no controller or machine is not on a domain
            { return null; }
            catch (ActiveDirectoryObjectNotFoundException) // controller found, but the machine is not known
            { return null; }
        }
