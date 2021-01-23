        public static void Main(string[] args)
        {
            using (var connection = new OdbcConnection("DSN=savior"))
            {
                const string Sql = "INSERT INTO Cortex( IdDA, Vlsd ) SELECT IDA, 'yes' FROM Dchas";
                connection.Open();
                using(var command = new OdbcCommand(Sql))
                {
                    int numberOfRecords = command.ExecuteNonQuery();
                    Console.WriteLine("Copied {0} rows.", numberOfRecords);
                }
            }
         }
