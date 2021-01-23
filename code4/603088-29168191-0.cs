        private void btnUnleash_Click(object sender, EventArgs e)
        {
            string serverName = "serverName";
            foreach (var user in GetLoggedUser(serverName))
            {
                dataGridView1.Rows.Add(serverName, user);
            }            
        }   
     
        private List<string> GetLoggedUser(string machineName)
        { 
            List<string> users = new List<string>();
            try
            {
                var scope = GetManagementScope(machineName);
                scope.Connect();
                var Query = new SelectQuery("SELECT LogonId  FROM Win32_LogonSession Where LogonType=10");
                var Searcher = new ManagementObjectSearcher(scope, Query);
                var regName = new Regex(@"(?<=Name="").*(?="")");
                foreach (ManagementObject WmiObject in Searcher.Get())
                {
                    foreach (ManagementObject LWmiObject in WmiObject.GetRelationships("Win32_LoggedOnUser"))
                    {
                        users.Add(regName.Match(LWmiObject["Antecedent"].ToString()).Value);
                    }
                }
            }
            catch (Exception ex)
            {
                users.Add(ex.Message);
            }
            return users;
        }
        private static ManagementScope GetManagementScope(string machineName)
        {
            ManagementScope Scope;
            if (machineName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "."), GetConnectionOptions());
            else
            {
                Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", machineName), GetConnectionOptions());
            }
            return Scope;
        }
        private static ConnectionOptions GetConnectionOptions()
        {
            var connection = new ConnectionOptions
            {
                EnablePrivileges = true,
                Authentication = AuthenticationLevel.PacketPrivacy,
                Impersonation = ImpersonationLevel.Impersonate,
            };
            return connection;
        }
