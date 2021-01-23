    public static bool Join(string dom,string usr, string pass)
        {
            // Define constants used in the method.
            int JOIN_DOMAIN = 1;
            int ACCT_CREATE = 2;
            int ACCT_DELETE = 4;
            int WIN9X_UPGRADE = 16;
            int DOMAIN_JOIN_IF_JOINED = 32;
            int JOIN_UNSECURE = 64;
            int MACHINE_PASSWORD_PASSED = 128;
            int DEFERRED_SPN_SET = 256;
            int INSTALL_INVOCATION = 262144;
            // Define parameters that we will use later when we invoke the method.
            // Remember, the username must have permission to join the object in the AD.
            //string domain = "domain";
            //string password = "password";
            //string username = "username";
            //string destinationOU = "destinationOU";
            // Here we will set the parameters that we like using the logical OR operator.
            // If you want to create the account if it doesn't exist you should add " | ACCT_CREATE "
            // For more information see: http://msdn.microsoft.com/en-us/library/aa392154%28VS.85%29.aspx
            int parameters = JOIN_DOMAIN | DOMAIN_JOIN_IF_JOINED;
            // The arguments are passed as an array of string objects in a specific order
            object[] methodArgs = { dom, pass, usr + "@" + dom, null, parameters };
            // Here we construct the ManagementObject and set Options
            ManagementObject computerSystem = new ManagementObject("Win32_ComputerSystem.Name='" + Environment.MachineName + "'");
            computerSystem.Scope.Options.Authentication = System.Management.AuthenticationLevel.PacketPrivacy;
            computerSystem.Scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            computerSystem.Scope.Options.EnablePrivileges = true;
            // Here we invoke the method JoinDomainOrWorkgroup passing the parameters as the second parameter
            object Oresult = computerSystem.InvokeMethod("JoinDomainOrWorkgroup", methodArgs);
            // The result is returned as an object of type int, so we need to cast.
            int result = (int)Convert.ToInt32(Oresult);
            // If the result is 0 then the computer is joined.
            if (result == 0)
            {
                MessageBox.Show("Joined Successfully!");
                return true;
            }
            else
            {
                // Here are the list of possible errors
                string strErrorDescription = " ";
                switch (result)
                {
                    case 5: strErrorDescription = "Access is denied";
                        break;
                    case 87: strErrorDescription = "The parameter is incorrect";
                        break;
                    case 110: strErrorDescription = "The system cannot open the specified object";
                        break;
                    case 1323: strErrorDescription = "Unable to update the password";
                        break;
                    case 1326: strErrorDescription = "Logon failure: unknown username or bad password";
                        break;
                    case 1355: strErrorDescription = "The specified domain either does not exist or could not be contacted";
                        break;
                    case 2224: strErrorDescription = "The account already exists";
                        break;
                    case 2691: strErrorDescription = "The machine is already joined to the domain";
                        break;
                    case 2692: strErrorDescription = "The machine is not currently joined to a domain";
                        break;
                }
                MessageBox.Show(strErrorDescription.ToString());
                return false;
            }
            
        }
