    private static string ResolveServiceNameLdap(string serviceName)
    {
        string tnsAdminPath = Path.Combine(@"C:\Apps\oracle\network\admin", "ldap.ora");
        string connectionString = string.Empty;
        // ldap.ora can contain many LDAP servers
        IEnumerable<string> directoryServers = null;
        if (File.Exists(tnsAdminPath))
        {
            string defaultAdminContext = string.Empty;
            using (var sr = File.OpenText(tnsAdminPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Ignore commetns
                    if (line.StartsWith("#"))
                    {
                        continue;
                    }
                    // Ignore empty lines
                    if (line == string.Empty)
                    {
                        continue;
                    }
                    // If line starts with DEFAULT_ADMIN_CONTEXT then get its value
                    if (line.StartsWith("DEFAULT_ADMIN_CONTEXT"))
                    {
                        defaultAdminContext = line.Substring(line.IndexOf('=') + 1).Trim(new[] {'\"', ' '});
                    }
                    // If line starts with DIRECTORY_SERVERS then get its value
                    if (line.StartsWith("DIRECTORY_SERVERS"))
                    {
                        string[] serversPorts = line.Substring(line.IndexOf('=') + 1).Trim(new[] {'(', ')', ' '}).Split(',');
                        directoryServers = serversPorts.SelectMany(x =>
                        {
                            // If the server includes multiple port numbers, this needs to be handled
                            string[] serverPorts = x.Split(':');
                            if (serverPorts.Count() > 1)
                            {
                                return serverPorts.Skip(1).Select(y => string.Format("{0}:{1}", serverPorts.First(), y));
                            }
                            return new[] {x};
                        });
                    }
                }
            }
            // Iterate through each LDAP server, and try to connect
            foreach (string directoryServer in directoryServers)
            {
                // Try to connect to LDAP server with using default admin contact
                try
                {
                    var directoryEntry = new DirectoryEntry("LDAP://" + directoryServer + "/" + defaultAdminContext, null, null, AuthenticationTypes.Anonymous);
                    var directorySearcher = new DirectorySearcher(directoryEntry, "(&(objectclass=orclNetService)(cn=" + serviceName + "))", new[] { "orclnetdescstring" }, SearchScope.Subtree);
                    SearchResult searchResult = directorySearcher.FindOne();
                    var value = searchResult.Properties["orclnetdescstring"][0] as byte[];
                    if (value != null)
                    {
                        connectionString = Encoding.Default.GetString(value);
                    }
                    // If the connection was successful, then not necessary to try other LDAP servers
                    break;
                }
                catch
                {
                    // If the connection to LDAP server not successful, try to connect to the next LDAP server
                    continue;
                }
            }
            // If casting was not successful, or not found any TNS value, then result is an error message
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "TNS value not found in LDAP";
            }
        }
        else
        {
            // If ldap.ora doesn't exist, then return error message
            connectionString = "ldap.ora not found";
        }
        return connectionString;
    }
