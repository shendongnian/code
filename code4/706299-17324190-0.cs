     #region Using Directives
    
        using System.Configuration;
        using System.Data.SqlClient;
        using System.IO;
        using Microsoft.SqlServer.Management.Common;
        using Microsoft.SqlServer.Management.Smo;
        using System.Xml.Linq;
        using System;
    
        #endregion
    
        public sealed class DatabaseHandler
        {
            #region Properties
    
            /// <summary>
            /// Returns the Database Connection String
            /// </summary>
            public string ConnectionString
            {
                get
                {
                    return ConfigurationManager.AppSettings["DbConnectionString"];
                }
            }
    
            #endregion
    
            #region Public Methods
    
            /// <summary>
            /// Reads the script conent from .sql file and execute on SQl Server
            /// </summary>
            /// <param name="scriptFilePath">.sql Script file path</param>
            /// <returns>Operation status <c>true: Success</c><c>false: Failed</c></returns>
            public bool ExecuteScript(string scriptFilePath)
            {
                try
                {
                    bool isCreated = false;
    
                    if (!string.IsNullOrWhiteSpace(scriptFilePath))
                    {
                        FileInfo fileInfo = new FileInfo(scriptFilePath);
    
                        if (null != fileInfo)
                        {
                            //Holds the sql script as string
                            string scriptText = string.Empty;
    
                            using (StreamReader reader = fileInfo.OpenText())
                            {
                                if (null != reader)
                                {
                                    scriptText = reader.ReadToEnd();
                                }
                            }
    
                            using (SqlConnection connection = new SqlConnection(ConnectionString))
                            {
                                Server sqlServer = new Server(new ServerConnection(connection));
    
                                if (null != sqlServer && null != sqlServer.ConnectionContext)
                                {
                                    sqlServer.ConnectionContext.ExecuteNonQuery(scriptText);
                                }
                            }
                        }
                    }
    
                    isCreated = true;
                    return isCreated;
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("Unable to find" + scriptFilePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            #endregion
        }
