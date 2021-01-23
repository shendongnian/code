        private string[,] GetImagesFromServerFolder()
        {
            IntPtr token;
            if (
                !NativeMethods.LogonUser([Server_Login_Name], [Server_Location],
                                         [Server_Login_Password], NativeMethods.LogonType.NewCredentials,
                                         NativeMethods.LogonProvider.Default, out token))
            {
                throw new Win32Exception();
            }
            try
            {
                IntPtr tokenDuplicate;
                if (!NativeMethods.DuplicateToken(
                    token,
                    NativeMethods.SecurityImpersonationLevel.Impersonation,
                    out tokenDuplicate))
                {
                    throw new Win32Exception();
                }
                try
                {
                    using (WindowsImpersonationContext impersonationContext =
                        new WindowsIdentity(tokenDuplicate).Impersonate())
                    {
                        /******************* CODE FROM HERE *******************/
                        List<string> files = new List<string>(Directory.GetFiles(_PHYSICAL SERVER LOCATION_));
                        
                        return files;
                        /******************* CODE TO HERE *******************/
                    }
                }
                finally
                {
                    if (tokenDuplicate != IntPtr.Zero)
                    {
                        if (!NativeMethods.CloseHandle(tokenDuplicate))
                        {
                            // Uncomment if you need to know this case.
                            ////throw new Win32Exception();
                        }
                    }
                }
            }
            finally
            {
                if (token != IntPtr.Zero)
                {
                    if (!NativeMethods.CloseHandle(token))
                    {
                        // Uncomment if you need to know this case.
                        ////throw new Win32Exception();
                    }
                }
            }
        }  
