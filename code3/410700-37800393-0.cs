        public const int STARTF_USESHOWWINDOW = 0x0000000;
        public const int SW_HIDE = 0;
       public static Process CreateProcessAsUser(string filename, string args)
        {
            var hToken = WindowsIdentity.GetCurrent().Token;
            var hDupedToken = IntPtr.Zero;
            var pi = new PROCESS_INFORMATION();
            var sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);
            try
            {
                if (!DuplicateTokenEx(
                        hToken,
                        GENERIC_ALL_ACCESS,
                        ref sa,
                        (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                        (int)TOKEN_TYPE.TokenPrimary,
                        ref hDupedToken
                    ))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                var si = new STARTUPINFO();
                si.cb = Marshal.SizeOf(si);
                si.lpDesktop = String.Empty; 
                si.dwFlags = STARTF_USESHOWWINDOW;
                si.wShowWindow = SW_HIDE;
                var path = Path.GetFullPath(filename);
                var dir = Path.GetDirectoryName(path);
                // Revert to self to create the entire process; not doing this might
                // require that the currently impersonated user has "Replace a process
                // level token" rights - we only want our service account to need
                // that right.
                using (var ctx = WindowsIdentity.Impersonate(IntPtr.Zero))
                {
                    UInt32 dwSessionId = 1;  // set it to session 0
                    SetTokenInformation(hDupedToken, TOKEN_INFORMATION_CLASS.TokenSessionId,
                        ref dwSessionId, (UInt32)IntPtr.Size);
                    if (!CreateProcessAsUser(
                                            hDupedToken,
                                            path,
                                            string.Format("\"{0}\" {1}", filename.Replace("\"", "\"\""), args),
                                            ref sa, ref sa,
                                            false, 0, IntPtr.Zero,
                                            dir, ref si, ref pi
                                    ))
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                return Process.GetProcessById(pi.dwProcessID);
            }
            finally
            {
                if (pi.hProcess != IntPtr.Zero)
                    CloseHandle(pi.hProcess);
                if (pi.hThread != IntPtr.Zero)
                    CloseHandle(pi.hThread);
                if (hDupedToken != IntPtr.Zero)
                    CloseHandle(hDupedToken);
            }
        }
