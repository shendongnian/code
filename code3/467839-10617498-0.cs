    public static class UserHelper
    {
        [Flags]
        public enum CREDUI_FLAGS
        {
            INCORRECT_PASSWORD = 0x1,
            DO_NOT_PERSIST = 0x2,
            REQUEST_ADMINISTRATOR = 0x4,
            EXCLUDE_CERTIFICATES = 0x8,
            REQUIRE_CERTIFICATE = 0x10,
            SHOW_SAVE_CHECK_BOX = 0x40,
            ALWAYS_SHOW_UI = 0x80,
            REQUIRE_SMARTCARD = 0x100,
            PASSWORD_ONLY_OK = 0x200,
            VALIDATE_USERNAME = 0x400,
            COMPLETE_USERNAME = 0x800,
            PERSIST = 0x1000,
            SERVER_CREDENTIAL = 0x4000,
            EXPECT_CONFIRMATION = 0x20000,
            GENERIC_CREDENTIALS = 0x40000,
            USERNAME_TARGET_CREDENTIALS = 0x80000,
            KEEP_USERNAME = 0x100000,
        }
        public enum CredUIReturnCodes
        {
            NO_ERROR = 0,
            ERROR_CANCELLED = 1223,
            ERROR_NO_SUCH_LOGON_SESSION = 1312,
            ERROR_NOT_FOUND = 1168,
            ERROR_INVALID_ACCOUNT_NAME = 1315,
            ERROR_INSUFFICIENT_BUFFER = 122,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_INVALID_FLAGS = 1004,
            ERROR_BAD_ARGUMENTS = 160
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CREDUI_INFO
        {
            public int cbSize;
            public IntPtr hwndParent;
            public string pszMessageText;
            public string pszCaptionText;
            public IntPtr hbmBanner;
        }
        [DllImport("credui", EntryPoint = "CredUIPromptForCredentialsW", CharSet = CharSet.Unicode)]
        private static extern CredUIReturnCodes CredUIPromptForCredentials(ref CREDUI_INFO creditUR, string targetName, IntPtr reserved1, int iError, StringBuilder userName, int maxUserName, StringBuilder password, int maxPassword, [MarshalAs(UnmanagedType.Bool)] ref bool pfSave, CREDUI_FLAGS flags);
        [DllImport("credui", EntryPoint = "CredUIParseUserNameW", CharSet = CharSet.Unicode)]
        private static extern CredUIReturnCodes CredUIParseUserName(string userName, StringBuilder user, int userMaxChars, StringBuilder domain, int domainMaxChars);
        const int MAX_USER_NAME = 100;
        const int MAX_PASSWORD = 100;
        const int MAX_DOMAIN = 100;
        public static CredUIReturnCodes PromptForCredentials(System.Windows.Window parentWindow, ref CREDUI_INFO creditUI, string targetName, int netError, out string domainName, out string userName, out string password, ref bool save, CREDUI_FLAGS flags)
        {
            userName = String.Empty;
            domainName = String.Empty;
            password = String.Empty;
            creditUI.cbSize = Marshal.SizeOf(creditUI);
            creditUI.hwndParent = new WindowInteropHelper(parentWindow).Handle;
            StringBuilder user = new StringBuilder(MAX_USER_NAME);
            StringBuilder pwd = new StringBuilder(MAX_PASSWORD);
            CredUIReturnCodes result = CredUIPromptForCredentials(ref creditUI, targetName, IntPtr.Zero, netError, user, MAX_USER_NAME, pwd, MAX_PASSWORD, ref save, flags);
            if (result == CredUIReturnCodes.NO_ERROR)
            {
                string tempUserName = user.ToString();
                string tempPassword = pwd.ToString();
                StringBuilder userBuilder = new StringBuilder();
                StringBuilder domainBuilder = new StringBuilder();
                CredUIReturnCodes returnCode = CredUIParseUserName(tempUserName, userBuilder, int.MaxValue, domainBuilder, int.MaxValue);
                switch (returnCode)
                {
                    case CredUIReturnCodes.NO_ERROR:
                        userName = userBuilder.ToString();
                        domainName = domainBuilder.ToString();
                        password = tempPassword;
                        return returnCode;
                    case CredUIReturnCodes.ERROR_INVALID_ACCOUNT_NAME:
                        userName = tempUserName;
                        domainName = String.Empty;
                        password = tempPassword;
                        return returnCode;
                    default:
                        return returnCode;
                }
            }
            return result;
        }
    }
