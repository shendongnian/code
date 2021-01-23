            SecureString password = new SecureString();
            string runasUsername = "USERNAME";
            string runasPassword = "PASSWORD";
            string liveIdconnectionUri = "http://EXCHANGE_SERVER/PowerShell";
            foreach (char x in runasPassword)
            {
                password.AppendChar(x);
            }
            PSCredential credential = new PSCredential(runasUsername, password);
            // Set the connection Info
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo((new Uri(liveIdconnectionUri)), "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
            credential);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default; //AuthenticationMechanism.Default;
            // create a runspace on a remote path
            // the returned instance must be of type RemoteRunspace
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            PowerShell powershell = PowerShell.Create();
            PSCommand command = new PSCommand();
            command.AddCommand("Enable-Mailbox");
            command.AddParameter("Identity", "MAIL_USER_ID_HERE");
            powershell.Commands = command;
            try
            {
                // open the remote runspace
                runspace.Open();
                // associate the runspace with powershell
                powershell.Runspace = runspace;
                // invoke the powershell to obtain the results
                var result = powershell.Invoke();
                if (result.Count > 0)
                    Console.WriteLine("sucessful!");
                else
                    Console.WriteLine("failed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // dispose the runspace and enable garbage collection
                runspace.Dispose();
                runspace = null;
                // Finally dispose the powershell and set all variables to null to free
                // up any resources.
                powershell.Dispose();
                powershell = null;
            }
            Console.WriteLine("done");
            Console.Read();
