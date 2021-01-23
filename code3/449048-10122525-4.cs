    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
                int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static bool CloseHandle(IntPtr handle);
    
            // Test harness.
            // If you incorporate this code into a DLL, be sure to demand FullTrust.
            [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
            private void button1_Click(object sender, EventArgs e)
            {
                SafeTokenHandle safeTokenHandle;
                const int LOGON32_PROVIDER_DEFAULT = 0;
                //This parameter causes LogonUser to create a primary token.
                const int LOGON32_LOGON_INTERACTIVE = 2;
                bool returnValue = LogonUser("administrator", "", "password",
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);
    
                Console.WriteLine("LogonUser called.");
    
                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    Console.WriteLine("LogonUser failed with error code : {0}", ret);
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (safeTokenHandle)
                {
                    Console.WriteLine("Did LogonUser Succeed? " + (returnValue ? "Yes" : "No"));
                    Console.WriteLine("Value of Windows NT token: " + safeTokenHandle);
    
                    // Check the identity.
                    Console.WriteLine("Before impersonation: "
                        + WindowsIdentity.GetCurrent().Name);
                    // Use the token handle returned by LogonUser.
                    WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                    using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                    {
                        System.Diagnostics.Process process = null;
                        System.Diagnostics.ProcessStartInfo processStartInfo;
    
    
                        processStartInfo = new System.Diagnostics.ProcessStartInfo();
    
                        processStartInfo.FileName = "regedit.exe";
                      
                        //if (System.Environment.OSVersion.Version.Major >= 6)  // Windows Vista or higher
                        //{
                        //    processStartInfo.Verb = "runas";
                        //}
                        //else
                        //{
                        //    // No need to prompt to run as admin
                        //}
    
                        processStartInfo.Arguments = "";
                        processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        processStartInfo.UseShellExecute = true;
    
                        try
                        {
                            process = System.Diagnostics.Process.Start(processStartInfo);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (process != null)
                            {
                                process.Dispose();
                            }
                        }
    
                        // Check the identity.
                        Console.WriteLine("After impersonation: "
                            + WindowsIdentity.GetCurrent().Name);
                    }
                    // Releasing the context object stops the impersonation
                    // Check the identity.
                    Console.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
                }
            }
