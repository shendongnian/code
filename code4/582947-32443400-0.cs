        string encryptedPassword = RunPowerShellCommand("\"" 
                + password 
                + "\" | ConvertTo-SecureString -AsPlainText -Force | ConvertFrom-SecureString", null);
        public static string RunPowerShellCommand(string command, 
            Dictionary<string, object> parameters)
        {
            using (PowerShell powerShellInstance = PowerShell.Create())
            {
                // Set up the running of the script
                powerShellInstance.AddScript(command);
                // Add the parameters
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        powerShellInstance.AddParameter(parameter.Key, parameter.Value);
                    }
                }
                // Run the command
                Collection<PSObject> psOutput = powerShellInstance.Invoke();
                StringBuilder stringBuilder = new StringBuilder();
                if (powerShellInstance.Streams.Error.Count > 0)
                {
                    foreach (var errorMessage in powerShellInstance.Streams.Error)
                    {
                        if (errorMessage != null)
                        {
                            throw new InvalidOperationException(errorMessage.ToString());
                        }
                    }
                }
                foreach (var outputLine in psOutput)
                {
                    if (outputLine != null)
                    {
                        stringBuilder.Append(outputLine);
                    }
                }
                return stringBuilder.ToString();
            }
        }
