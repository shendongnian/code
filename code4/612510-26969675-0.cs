    private static void Impersonate(string userName, string domain, string password, LogOnType logonType, LogOnProvider logonProvider, ImpersonationLevel impersonationLevel)
    {
        var token = IntPtr.Zero;
        var tokenDuplicate = IntPtr.Zero;
        if (NativeMethods.RevertToSelf())
        {
            var logonUserSuccessful = NativeMethods.LogonUser(userName, domain, password, (int) logonType, (int) logonProvider, ref token);
            /* avoid CA1404 */
            var e = Marshal.GetLastWin32Error();
            if (logonUserSuccessful != 0)
            {
                if (NativeMethods.DuplicateToken(token, (int)impersonationLevel, ref tokenDuplicate) != 0)
                {
                    /* CA2000 */
                    using (var tempWindowsIdentity = new WindowsIdentity(tokenDuplicate))
                    {
                        _impersonationContext = tempWindowsIdentity.Impersonate();
                        return;
                    }
                }
            }
        }
        throw new Win32Exception(e);
    }
