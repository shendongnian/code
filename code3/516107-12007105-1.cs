    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Xml;
    
    class SqlServerDatabaseService : IDatabaseService
    {
        // creates a connection based on connection string from App.config: 
        SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["SqlServerDatabase"].ConnectionString);
        }
    
        // stores an XML document into the 'ApplicationDocuments' table: 
        public void StoreApplicationDocument(string applicationName, XmlReader document)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO ApplicationDocuments (ApplicationName, Document) VALUES (@applicationName, @document)";
                command.Parameters.Add(new SqlParameter("@applicationName", applicationName));
                command.Parameters.Add(new SqlParameter("@document", new SqlXml(document)));
                                                                 //  ^^^^^^^^^^^^^^^^^^^^
                connection.Open();
                int numberOfRowsInserted = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    
        // reads an XML document from the 'ApplicationDocuments' table:
        public XmlReader GetApplicationXslt(string applicationName)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Document FROM ApplicationDocuments WHERE ApplicationName = @applicationName";
                command.Parameters.Add(new SqlParameter("@applicationName", applicationName));
    
                connection.Open();
                var plainXml = (string)command.ExecuteScalar();
                connection.Close();
    
                if (plainXml != null)
                {
                    return XmlReader.Create(new StringReader(plainXml));
                }
                else
                {
                    throw new KeyNotFoundException(message: string.Format("Database does not contain a application document named '{0}'.", applicationName));
                }
            }
        }
    
        … // (all other methods throw a NotImplementedException)
    }
