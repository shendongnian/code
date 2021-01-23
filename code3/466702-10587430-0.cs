    public static bool IsRunAsAdministrator
    {
        get
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity.IsSystem) return true;
            
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            if (windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                return true;
            
            //Vista or higher check
            if (Environment.OSVersion.Version.Major >= 6)
            {
                IntPtr hToken = IntPtr.Zero;
                try
                {
                    if (!OpenProcessToken(GetCurrentProcess(), TOKEN_QUERY, out hToken))
                        Win32.ThrowLastError();
    
                    TOKEN_ELEVATION_TYPE elevationType;
                    IntPtr pElevationType = Marshal.AllocHGlobal(sizeof(TOKEN_ELEVATION_TYPE));
                    uint dwSize;
    
                    if (!GetTokenInformation(
                        hToken,
                        TOKEN_INFORMATION_CLASS.TokenElevationType,
                        pElevationType,
                        sizeof(TOKEN_ELEVATION_TYPE),
                        out dwSize
                        ))
                        Win32.ThrowLastError();
    
                    elevationType = (TOKEN_ELEVATION_TYPE)Marshal.ReadInt32(pElevationType);
                    Marshal.FreeHGlobal(pElevationType);
    
                    return elevationType == TOKEN_ELEVATION_TYPE.TokenElevationTypeFull;
                }
                finally
                {
                    CloseHandle(hToken);
                }
            }
            else
                return true;
        }
    }
