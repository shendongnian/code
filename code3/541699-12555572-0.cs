    using MySql.Data.MysqlClient;
    namespace OwnNameSpace
    {
      public class Database
      {
        MySqlConnection connect;
        string connection = "Data Source=localhost;Database=ASP;User ID=(your ID)";
    //constructor
    public Database()
    {
    }
      // this if want to select something in your db
      public MySqlDataReader Select(string query)
      {
        
          connect = new MySqlConnection(connection);
          connect.Close();
          MySqlCommand command = connect.CreateCommand();
          command.CommandText = query;
          connect.Open();
          MySqlDataReader reader;
          return reader = command.ExecuteReader();
      }
 
      // this if want to insert/delete or update 
      public Boolean Modify(string query)
      {
        
          connect = new MySqlConnection(connection);
          MySqlCommand command = connect.CreateCommand();
          command.CommandText = query;
          connect.Open();
          try
          {
             command.ExecuteNonQuery();
             return true;
          }
          catch
          {
            return false;
          }
          
       }
 
     }
    }
