    public class CodeImpersonate
    {
        /// <summary>
        /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, 
        /// remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore,
        /// it is inappropriate for some client/server applications, such as a mail server.
        /// </summary>
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        /// <summary>
        /// Use the standard logon provider for the system. The default security provider is negotiate, 
        /// unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM.
        /// Windows 2000: The default security provider is NTLM.
        /// </summary>
        public const int LOGON32_PROVIDER_DEFAULT = 0;
    
        WindowsImpersonationContext impersonationContext;
    
        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName,
                                            String lpszDomain,
                                            String lpszPassword,
                                            int dwLogonType,
                                            int dwLogonProvider,
                                            ref IntPtr phToken);
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();
    
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);      
    
        public bool ImpersonateValidUser(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
    
            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
            return false;
        }
    
        public void UndoImpersonation()
        {
            if (impersonationContext != null)
                impersonationContext.Undo();
        }
