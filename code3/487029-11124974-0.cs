    //Note the IDisposable interface
    public class MultiSqlCommand : IDisposable
    {
      //DbConnectionType  is a custom enum
      public MultiSqlCommand(DbConnectionType connType, DbConnection conn)
      {
        //initialize members
        ...
        switch(connType) 
        {
          case ADO:
            _cmd = new SqlCommand(_connection);
            break;
          case ODBC:
            ...
        }
      }
    
      //As param name you pass the undecorated parameter name (no @, ?, etc.)
      public void AddParameter(string strippedName, string value) 
      {
        //this should be an internal function which gives you an SqlParameter formatted for your specific DbConnectionType
        object parameter = GetDecoratedParamName(strippedName, value);
        _cmd.Parameters.Add(object);
      }
    }
