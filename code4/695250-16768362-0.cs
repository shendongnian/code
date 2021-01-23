    class Program
    {
        static void Main(string[] args)
        {
            System.Data.SqlClient.SqlConnection.ChangePassword(
            "Data Source=a_server;Initial Catalog=a_database;UID=user;PWD=old_password", 
           "new_password");
        }
    }
