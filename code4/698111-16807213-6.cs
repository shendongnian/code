    private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                IntPtr token = cls.ImpersonateUser("username", "domain", "password");
                using (WindowsImpersonationContext impersonatedUser = WindowsIdentity.Impersonate(token))
                {
                    string fileName = @"\\network_computer\Test\Test.doc";
                    System.Diagnostics.Process.Start(fileName);
                }
                cls.FreeImpersonationResource(token);
            }
            catch (Exception ex) { throw ex; }
        }
