        try
        {
            // Create a token for DomainName\Bob
            // Note: Credentials should be encrypted in configuration file
            bool result = LogonUser("Bob", "DomainName",
                                    "P@ssw0rd",
                                    LogonSessionType.Network,
                                    LogonProvider.Default,
                                    out token);
            if (result)
            {
                WindowsIdentity id = new WindowsIdentity(token);
                
                // Begin impersonation
                impersonatedUser = id.Impersonate();
                // Log the new identity
                Response.Write(String.Format(
                               "</p>Identity after impersonation: {0}<br>",
                               WindowsIdentity.GetCurrent().Name));
                // Resource access here uses the impersonated identity
            }
            else
            {
                Response.Write("</p>LogonUser failed: " +
                               Marshal.GetLastWin32Error().ToString());
            }
        }
        catch
        {
            // Prevent any exceptions that occur while the thread is 
            // impersonating from propagating
        }
        finally
        {
            // Stop impersonation and revert to the process identity
            if (impersonatedUser != null)
                impersonatedUser.Undo();
            // Free the token
            if (token != IntPtr.Zero)
                CloseHandle(token);
        }
