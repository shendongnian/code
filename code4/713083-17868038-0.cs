    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.ComponentModel;
    /// <summary>
    /// Class to impersonate another user. Requires user, pass and domain/computername
    /// All code run after impersonationuser has been run will run as this user.
    /// Remember to Dispose() afterwards.
    /// </summary>
    public class ImpersonateUser:IDisposable {
        private WindowsImpersonationContext LastContext = null;
        private IntPtr LastUserHandle = IntPtr.Zero;
        #region User Impersonation api
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool ImpersonateLoggedOnUser(int Token);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DuplicateToken(IntPtr token, int impersonationLevel, ref IntPtr duplication);
        [DllImport("kernel32.dll")]
        public static extern Boolean CloseHandle(IntPtr hObject);
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        public const int LOGON32_PROVIDER_WINNT35 = 1;
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_LOGON_NETWORK = 3;
        public const int LOGON32_LOGON_BATCH = 4;
        public const int LOGON32_LOGON_SERVICE = 5;
        public const int LOGON32_LOGON_UNLOCK = 7;
        public const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;// Win2K or higher
        public const int LOGON32_LOGON_NEW_CREDENTIALS = 9;// Win2K or higher
        #endregion
        public ImpersonateUser(string username, string domainOrComputerName, string password, int nm = LOGON32_LOGON_NETWORK) {
            IntPtr userToken = IntPtr.Zero;
            IntPtr userTokenDuplication = IntPtr.Zero;
            
            bool loggedOn = false;
            
            if (domainOrComputerName == null) domainOrComputerName = Environment.UserDomainName;
            if (domainOrComputerName.ToLower() == "nt authority") {
                loggedOn = LogonUser(username, domainOrComputerName, password, LOGON32_LOGON_SERVICE, LOGON32_PROVIDER_DEFAULT, out userToken);
            } else {
                loggedOn = LogonUser(username, domainOrComputerName, password, nm, LOGON32_PROVIDER_DEFAULT, out userToken);
            }
            WindowsImpersonationContext _impersonationContext = null;
            if (loggedOn) {
                try {
                    // Create a duplication of the usertoken, this is a solution
                    // for the known bug that is published under KB article Q319615.
                    if (DuplicateToken(userToken, 2, ref userTokenDuplication)) {
                        // Create windows identity from the token and impersonate the user.
                        WindowsIdentity identity = new WindowsIdentity(userTokenDuplication);
                        _impersonationContext = identity.Impersonate();
                    } else {
                        // Token duplication failed!
                        // Use the default ctor overload
                        // that will use Mashal.GetLastWin32Error();
                        // to create the exceptions details.
                        throw new Win32Exception();
                    }
                } finally {
                    // Close usertoken handle duplication when created.
                    if (!userTokenDuplication.Equals(IntPtr.Zero)) {
                        // Closes the handle of the user.
                        CloseHandle(userTokenDuplication);
                        userTokenDuplication = IntPtr.Zero;
                    }
                    // Close usertoken handle when created.
                    if (!userToken.Equals(IntPtr.Zero)) {
                        // Closes the handle of the user.
                        CloseHandle(userToken);
                        userToken = IntPtr.Zero;
                    }
                }
            } else {
                // Logon failed!
                // Use the default ctor overload that 
                // will use Mashal.GetLastWin32Error();
                // to create the exceptions details.
                throw new Win32Exception();
            }
            if (LastContext == null) LastContext = _impersonationContext;
        }
        public void Dispose() {
            LastContext.Undo();
            LastContext.Dispose();
        }
    }
