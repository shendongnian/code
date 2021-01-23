    //factory inerface
    public inteface DataBaseCommonFactory()
    {
       ///you all coomon methods are here
      public bool createuser();
    }
    
    
    //DAtabase specifc classes
    
    //sql server
    public class SqlServer : DataBaseCommonFactory
    {
       public bool createuser()
       {
          //implementation
       }
    }
    
    //oracle server
    public class OracleServer : DataBaseCommonFactory
    {
       public bool createuser()
       {
          //implementation
       }
    }
    
    
    //mysql server
    public class MySqlServer : DataBaseCommonFactory
    {
       public bool createuser()
       {
          //implementation
       }
    }
    
    
    public class DataBaseCreationFactory
    {
       public DataBaseCreationFactory(string DatabaseType)//this might be enum
       {
          if(DatabaseType == "Sqlserver")
            return new SqlSErver();
          if(DatabaseType == "Oracleserver")
            return new OracleSErver();    //same for mysql or anyother datavase
       }
    }
    
    
    public class Client 
    {
       public void mymethod()
       {
          DataBaseCommonFactory sqlobject =  new DataBaseCreationFactory("Sqlserver")
          sqlobject.CreateUser();
          //if oracle is ther than parameter is orcalserver - or anyother database
        }
    }
