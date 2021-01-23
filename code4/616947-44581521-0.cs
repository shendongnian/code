    using System;
    using System.Data;
    using System.DirectoryServices;
    using System.Text;
    using Oracle.ManagedDataAccess.Client;
    
    namespace BAT
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string directoryServer = "myServer:389";
                string defaultAdminContext = "cn=OracleContext,dc=world";
                string serviceName = "MYDB";
                string userId = "MYUSER";
                string password = "MYPW";
    
                using (IDbConnection connection = GetConnection(directoryServer, defaultAdminContext, serviceName, userId,
                        password))
                {
                    connection.Open();
    
                    connection.Close();
                }
    
            }
    
            private static IDbConnection GetConnection(string directoryServer, string defaultAdminContext,
                string serviceName, string userId, string password)
            {
                string descriptor = ConnectionDescriptor(directoryServer, defaultAdminContext, serviceName);
                // Connect to Oracle
                string connectionString = $"user id={userId};password={password};data source={descriptor}";
    
                OracleConnection con = new OracleConnection(connectionString);
                return con;
            } 
    
            private static string ConnectionDescriptor(string directoryServer, string defaultAdminContext,
                string serviceName)
            {
                string ldapAdress = $"LDAP://{directoryServer}/{defaultAdminContext}";
                string query = $"(&(objectclass=orclNetService)(cn={serviceName}))";
                string orclnetdescstring = "orclnetdescstring";
    
                DirectoryEntry directoryEntry = new DirectoryEntry(ldapAdress, null, null, AuthenticationTypes.Anonymous);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry, query, new[] { orclnetdescstring },
                    SearchScope.Subtree);
    
                SearchResult searchResult = directorySearcher.FindOne();
                byte[] value = searchResult.Properties[orclnetdescstring][0] as byte[];
    
                if (value != null)
                {
                    string descriptor = Encoding.Default.GetString(value);
                    return descriptor;
                }
                throw new Exception("Error qerying ldap");
            }
        }
    }
