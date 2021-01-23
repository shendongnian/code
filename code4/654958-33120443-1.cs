    public static object remoteWMIQuery(string machine, string username, string password, string WMIQuery, string property, ref bool jobOK)
        {
            jobOK = true;
            if (username == "")
            {
                username = null;
                password = null;
            }
            // Configure the connection settings.
            ConnectionOptions options = new ConnectionOptions();
            options.Username = username; //could be in domain\user format
            options.Password = password;
            ManagementPath path = new ManagementPath(String.Format("\\\\{0}\\root\\cimv2", machine));
            ManagementScope scope = new ManagementScope(path, options);
            // Try and connect to the remote (or local) machine.
            try
            {
                scope.Connect();
            }
            catch (ManagementException ex)
            {
                // Failed to authenticate properly.
                jobOK = false;
                return "Failed to authenticate: " + ex.Message;
                //p_extendederror = (int)ex.ErrorCode;
                //return Status.AuthenticateFailure;
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // Unable to connect to the RPC service on the remote machine.
                jobOK = false;
                return "Unable to connect to RPC service";
                //p_extendederror = ex.ErrorCode;
                //return Status.RPCServicesUnavailable;
            }
            catch (System.UnauthorizedAccessException)
            {
                // User not authorized.
                jobOK = false;
                return "Error: Unauthorized access";
                //p_extendederror = 0;
                //return Status.UnauthorizedAccess;
            }
            try
            {
                ObjectQuery oq = new ObjectQuery(WMIQuery);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, oq);
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (property != null)
                    {
                        return queryObj[property];
                    }
                    else return queryObj;
                }
            }
            catch (Exception e)
            {
                jobOK = false;
                return "Error: " + e.Message;
            }
            return "";
        }
