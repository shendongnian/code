            Console.Write("Target: ");
            var target = Console.ReadLine();
            Console.Write("User: ");
            var user = Console.ReadLine();
            user = string.Format("{0}\\{1}", target, user);
            string shell = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
            var targetWsMan = new Uri(string.Format("http://{0}:5985/wsman", target));
            using (var passing = new SecureString())
            {
                Console.Write("Password: ");
                var cki = default(ConsoleKeyInfo);
                do
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                        Console.Write(cki.KeyChar);
                    else
                        passing.AppendChar(cki.KeyChar);
                }
                while (cki.Key != ConsoleKey.Enter);
                passing.MakeReadOnly();
                var cred = new PSCredential(user, passing);
                var connectionInfo = new WSManConnectionInfo(targetWsMan, shell, cred);
                connectionInfo.OperationTimeout = 4 * 60 * 1000; // 4 minutes.
                connectionInfo.OpenTimeout = 1 * 60 * 1000;
                using (var runSpace = RunspaceFactory.CreateRunspace(connectionInfo))
                {
                    var p = runSpace.CreatePipeline();
                    runSpace.Open();
                    Console.WriteLine("Connected to {0}", targetWsMan);
                    Console.WriteLine("As {0}", user);
                    Console.Write("Command to run: ");
                    var cmd = Console.ReadLine();
                    p.Commands.Add(cmd);
                    var returnValue = p.Invoke();
                    foreach (var v in returnValue)
                        Console.WriteLine(v.ToString());
                }
            }
            Console.WriteLine("End...");
            Console.ReadLine();
