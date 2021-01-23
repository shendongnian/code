    class Program
    {
      static void Main(string[] args)
      {
      string connectionString = GetConnectionString();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
       // Connect to the database then retrieve the schema information.
       connection.Open();
       DataTable table = connection.GetSchema("Tables");
    
       // Display the contents of the table.
       DisplayData(table);
       Console.WriteLine("Press any key to continue.");
       Console.ReadKey();
       }
     }
