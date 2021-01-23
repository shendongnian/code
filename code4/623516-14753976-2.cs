    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public extern static bool DuplicateToken(IntPtr existingTokenHandle, int impersonationLevel, ref IntPtr duplicateTokenHandle);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool CloseHandle(IntPtr handle);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool RevertToSelf();
    [DllImport("userenv.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool LoadUserProfile(IntPtr hToken, ref ProfileInfo lpProfileInfo);
    [DllImport("Userenv.dll", CallingConvention =
        CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool UnloadUserProfile
        (IntPtr hToken, IntPtr lpProfileInfo);
    [DllImport("ole32.dll")]
    public static extern int CoInitializeSecurity(IntPtr pVoid, int
        cAuthSvc, IntPtr asAuthSvc, IntPtr pReserved1, RpcAuthnLevel level,
        RpcImpLevel impers, IntPtr pAuthList, EoAuthnCap dwCapabilities, IntPtr
        pReserved3);
    [StructLayout(LayoutKind.Sequential)]
    public struct ProfileInfo
    {
        ///
        /// Specifies the size of the structure, in bytes.
        ///
        public int dwSize;
        ///
        /// This member can be one of the following flags: 
        /// PI_NOUI or PI_APPLYPOLICY
        ///
        public int dwFlags;
        ///
        /// Pointer to the name of the user.
        /// This member is used as the base name of the directory 
        /// in which to store a new profile.
        ///
        public string lpUserName;
        ///
        /// Pointer to the roaming user profile path.
        /// If the user does not have a roaming profile, this member can be NULL.
        ///
        public string lpProfilePath;
        ///
        /// Pointer to the default user profile path. This member can be NULL.
        ///
        public string lpDefaultPath;
        ///
        /// Pointer to the name of the validating domain controller, in NetBIOS format.
        /// If this member is NULL, the Windows NT 4.0-style policy will not be applied.
        ///
        public string lpServerName;
        ///
        /// Pointer to the path of the Windows NT 4.0-style policy file. 
        /// This member can be NULL.
        ///
        public string lpPolicyPath;
        ///
        /// Handle to the HKEY_CURRENT_USER registry key.
        ///
        public IntPtr hProfile;
    }
    public enum RpcAuthnLevel
    {
        Default = 0,
        None = 1,
        Connect = 2,
        Call = 3,
        Pkt = 4,
        PktIntegrity = 5,
        PktPrivacy = 6
    }
    public enum RpcImpLevel
    {
        Default = 0,
        Anonymous = 1,
        Identify = 2,
        Impersonate = 3,
        Delegate = 4
    }
    public enum EoAuthnCap
    {
        None = 0x00,
        MutualAuth = 0x01,
        StaticCloaking = 0x20,
        DynamicCloaking = 0x40,
        AnyAuthority = 0x80,
        MakeFullSIC = 0x100,
        Default = 0x800,
        SecureRefs = 0x02,
        AccessControl = 0x04,
        AppID = 0x08,
        Dynamic = 0x10,
        RequireFullSIC = 0x200,
        AutoImpersonate = 0x400,
        NoCustomMarshal = 0x2000,
        DisableAAA = 0x1000
    }
    
    const int LOGON32_PROVIDER_DEFAULT = 0;
    const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
    const int SECURITY_IMPERSONATION_LEVEL = 2;
    public void RunOperationAsUser(Action operation, string userName, string domain, string password)
    {
        IntPtr token = IntPtr.Zero;
        IntPtr dupToken = IntPtr.Zero;
        //Impersonate the user
        if (LogonUser(userName, domain, password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT, ref token))
        {
            if (DuplicateToken(token, SECURITY_IMPERSONATION_LEVEL, ref dupToken))
            {
                WindowsIdentity newIdentity = new WindowsIdentity(dupToken);
                WindowsImpersonationContext impersonatedUser = newIdentity.Impersonate();
                int retCode = CoInitializeSecurity(IntPtr.Zero, -1, IntPtr.Zero, IntPtr.Zero,
                    RpcAuthnLevel.PktPrivacy, RpcImpLevel.Impersonate, IntPtr.Zero, EoAuthnCap.DynamicCloaking, IntPtr.Zero);
                if (impersonatedUser != null)
                {
                    var username = WindowsIdentity.GetCurrent(TokenAccessLevels.MaximumAllowed).Name;
                    var sid = WindowsIdentity.GetCurrent(TokenAccessLevels.MaximumAllowed).User.Value;
                    ProfileInfo profileInfo = new ProfileInfo();
                    profileInfo.dwSize = Marshal.SizeOf(profileInfo);
                    profileInfo.lpUserName = userName;
                    profileInfo.dwFlags = 1;
                    Boolean loadSuccess = LoadUserProfile(dupToken, ref profileInfo);
                }
                operation();
                impersonatedUser.Undo();
            }
        }
        if (token != IntPtr.Zero)
        {
            CloseHandle(token);
        }
        if (dupToken != IntPtr.Zero)
        {
            try
            {
                CloseHandle(token);
            }
            catch
            { }
        }
    }
