        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IntPtr token = cls.ImpersonateUser("username", "domain", "password");
                using (WindowsImpersonationContext impersonatedUser = WindowsIdentity.Impersonate(token))
                {
                    string fileName = @"Winword.exe"; // the name of the sw you will use to open your file, I suppose MS Word
                    string argument = @"\\network_computer\Test\Test.doc"; // the path pf the file you want to open
                    Process process = new Process();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = fileName;
                    info.Arguments = argument;
                    process.StartInfo = info;
                    process.Start();
                }
                cls.FreeImpersonationResource(token);
            }
            catch (Exception ex) { throw ex; }
        }
