    using(SqlConnection _sqlConnection = per==null?
          new SqlConnection(IRLConfigurationManager.GetConnectionString("connectionStringIRL"))
          : per.GetConnection())
    using(SqlCommand sqlCmd = per==null?
          new SqlCommand("usp_UpdateDocumentStatusInImages", _sqlConnection);
          : per.GenerateCommand("usp_UpdateDocumentStatusInImages", 
           _sqlConnection, per))
    {
      //Code here using command and connection
    }
