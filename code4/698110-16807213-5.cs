    public class clsImpersonate
    {
        #region 'Impersonation'
        // obtains user token
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        // closes open handes returned by LogonUser
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        public IntPtr ImpersonateUser(string sUsername, string sDomain, string sPassword)
        {
            // initialize token
            IntPtr pExistingTokenHandle = new IntPtr(0);
            // if domain name was blank, assume local machine
            if (sDomain == "")
                sDomain = System.Environment.MachineName;
            try
            {
                string sResult = null;
                const int LOGON32_PROVIDER_DEFAULT = 0;
                // create token
                const int LOGON32_LOGON_INTERACTIVE = 2;
                // get handle to token
                bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);
                // did impersonation fail?
                if (false == bImpersonated)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";
                    // show the reason why LogonUser failed
                    //MessageBox.Show(sResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Get identity before impersonation
                sResult += "Before impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";
                return pExistingTokenHandle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool FreeImpersonationResource(IntPtr _token)
        {
            // close handle(s)
            if (_token != IntPtr.Zero)
                return CloseHandle(_token);
            else return true;
        }
        #endregion
    }
