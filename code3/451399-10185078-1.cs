    public class FactoryMethods
    {
      public static MySqlConnection GetConfiguredConnection()
      {
        OldCompatibility.BinaryAsString = true;
        MySqlConnection conn = new MySqlConnectio("User id=root;pwd=root;port=3306;host=localhost;database=test");
        conn.Open();
        return conn;
      }
    }
