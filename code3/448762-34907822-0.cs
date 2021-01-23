    using System.Management.Automation;
    using System.Management.Automation.Remoting;
    using System.Management.Automation.Host;
    using System.Collections.ObjectModel;
    using Microsoft.PowerShell.Commands;
    static string createmailbox(string name, string alias, string email, string database, string UPN)
            {
    
                SecureString spassword = new SecureString();
                string PassWord = "<set default password here or read in input from form>";
                spassword.Clear();
    
                foreach (char c in PassWord)
                {
                    spassword.AppendChar(c);
                }
                
                string orgunit = "<define the OU here if you always use the same one, alternatively, add as parameter in function call>";
                string dc = "<similarly, add DC here if needed, or call  from function>";
                PSCredential newCred = (PSCredential)null;
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("<put in CAS server FQDN here>/powershell?serializationLevel=Full"),
                    "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
                connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
                Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
                PowerShell powershell = PowerShell.Create();
    
                PSCommand command = new PSCommand();
                command.AddCommand("New-Mailbox");
                command.AddParameter("-Name", name);
                command.AddParameter("-Alias", alias);
                command.AddParameter("-UserPrincipalName", email);
                command.AddParameter("-PrimarySMTPAddress", email);
                command.AddParameter("-Password",spassword);
                // (ConvertTo-SecureString -AsPlainText "P4ssw0rd" -Force)
                command.AddParameter("-Database", database);
                command.AddParameter("-OrganizationalUnit", orgunit);
     //           command.AddParameter("-Email", email);
                command.AddParameter("-DomainController", dc);
                powershell.Commands = command;
                try
                {
                    runspace.Open();
                    powershell.Runspace = runspace;
                    Collection<PSObject> results = powershell.Invoke();
                    return results.ToString();
                }
                catch (Exception ex)
                {
                    string er = ex.InnerException.ToString();
                    
                }
                finally
                {
                    runspace.Dispose();
                    runspace = null;
    
                    powershell.Dispose();
                    powershell = null;
    
                }
            }
