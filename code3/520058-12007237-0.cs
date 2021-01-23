            var target = "the_hostname";
            var user = string.Format("{0}\\the_username", target);
            string shell = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
            var targetWsMan = new Uri(string.Format("http://{0}/wsman", target));
            using (var runSpace = RunspaceFactory.CreateRunspace())
            {
                var p = runSpace.CreatePipeline();
                using (var passing = new SecureString())
                {
                    string password = "password123$";
                    foreach (char c in password)
                        passing.AppendChar(c);
                    passing.MakeReadOnly();
                    var cred = new PSCredential(user, passing);
                    var connectionInfo = new WSManConnectionInfo(targetWsMan, shell, cred);
                    connectionInfo.OperationTimeout = 4 * 60 * 1000; // 4 minutes.
                    connectionInfo.OpenTimeout = 1 * 60 * 1000;
                    runSpace.Open();
                    p.Commands.Add("HOSTNAME");
                    var returnValue = p.Invoke();
                    foreach (var v in returnValue)
                        Console.WriteLine(v.ToString());
                }
            }
            Console.WriteLine("End...");
            Console.ReadLine();
