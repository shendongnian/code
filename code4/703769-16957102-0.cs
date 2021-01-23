    using System.Data.OleDb;
    
        public class DataAccess
        {
        
              public void Connect(Action<OleDbConnection> action)
              {
                        using(var cnn=new OleDbConnection())
                       {
                           cnn.ConnectionString="Provider=MySqlProv;Data Source=ServerName;User id=UserName;Password=Password;" 
                           cnn.Open();
                           action(cnn);
                       }
               }
        }
