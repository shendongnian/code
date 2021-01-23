      public static class DatabaseManager
        {
            //set connection string for SQL Server Express Edition
            static string connString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=DocumentStore;Integrated Security=True;Pooling=False";
    
    
            //method to save document to database
            public static bool SaveDocumentToDatabase(MemoryStream msDocument, DocumentType docType, string documentName)
            {
                //keep track of the save status 
                bool isSaved = false;
    
                //create database connection
                SqlConnection sqlConnection = new SqlConnection(connString);
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Settings.LogException(ex);
                    Console.WriteLine("Unable to open database connection");
                    isSaved = false;
                }
    
                string commandText = "INSERT INTO Documents (DocumentType, DocumentName, DocumentContent, CreateDate) VALUES('" + docType + "','" + documentName + "', @DocumentContent ,'" + DateTime.Now + "')";
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("DocumentContent", msDocument.ToArray());
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Document saved successfully");
                    isSaved = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unable to save the document to database");
                    Settings.LogException(ex);
                    isSaved = false;
                }
    
                //close database connect
                sqlConnection.Close();
    
    
                return isSaved;
            }
        public static bool LoadDocumentFromDataBase(DocumentType docType)
        {
             //keep track of the retrieve status 
            bool isRetrieved = false;
            //create database connection
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to open database connection");
                Settings.LogException(ex);
                isRetrieved = false;
            }
            string commandText = "SELECT * FROM Documents WHERE DocumentType ='" + docType + "'";
          
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandText, sqlConnection);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            DataTable dtDocuments = new DataTable();
            try
            {
                sqlDataAdapter.Fill(dtDocuments);
                Console.WriteLine("Document retrieved successfully");
                isRetrieved = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to retrieve documents from database");
                Settings.LogException(ex);
                isRetrieved = false;
            }
       }
    }
