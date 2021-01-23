    class Program
    {
        static void Main(string[] args)
        {
            // add here your connection details
            String connectionString = "Server=localhost;Database=database;Uid=username;Pwd=password;";
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
           
                Console.WriteLine("MySQL version: " + connection.ServerVersion);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
                Console.ReadKey();
        }
    }
