    using (new RDPCredentials(Host, UserPrincipalName, Password))
    {
        /*Do the RDP work here*/
    }
------
    internal class RDPCredentials : IDisposable
    {
        private string Host { get; }
        public RDPCredentials(string Host, string UserName, string Password)
        {
            var cmdkey = new Process
            {
                StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                    Arguments = $@"/list",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            cmdkey.Start();
            cmdkey.WaitForExit();
            if (!cmdkey.StandardOutput.ReadToEnd().Contains($@"TERMSRV/{Host}"))
            {
                this.Host = Host;
                cmdkey = new Process
                {
                    StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                    Arguments = $@"/generic:TERMSRV/{Host} /user:{UserName} /pass:{Password}",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
                };
                cmdkey.Start();
            }
        }
        public void Dispose()
        {
            if (Host != null)
            {
                var cmdkey = new Process
                {
                    StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                    Arguments = $@"/delete:TERMSRV/{Host}",
                    WindowStyle = ProcessWindowStyle.Hidden
                }
                };
                cmdkey.Start();
            }
        }
    }
