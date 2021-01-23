    public string getWMI(string[] parameters)
        {
            string ip = parameters[0];
            string username = parameters[1];
            string password = parameters[2];
            string query = parameters[3];
            string result = "";
            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope;
            options.Username = username;
            options.Password = password;
            try
            {
                scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2", options);
                scope.Connect();
                if (scope.IsConnected)
                {
                    ObjectQuery q = new ObjectQuery(query);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, q);
                    ManagementObjectCollection objCol = searcher.Get();
                    foreach (ManagementObject mgtObject in objCol)
                    {
                        result = result + mgtObject.GetText(TextFormat.CimDtd20);
                    }
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                writeLogFile("WMI Error: " + e.Message);
                writeLog("WMI Error: " + e.Message);
            }
            return result;
        }
