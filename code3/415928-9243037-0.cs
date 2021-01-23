    class Program
    {
        private static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["db"].ConnectionString; }
        }
        static void Main(string[] args)
        {
            int recordCount = 0;
            int lastId = -1;
            bool done = false;
            Stopwatch timer = Stopwatch.StartNew();
            do
            {
                done = true;
                IEnumerable<TransactionHistory> transactionDataRecords = GetTransactions(lastId, 10000);
                foreach (TransactionHistory transactionHistory in transactionDataRecords)
                {
                    lastId = transactionHistory.TransactionId;
                    done = false;
                    recordCount++;
                }
            } while (!done);
            timer.Stop();
            Console.WriteLine("Processed {0} records in {1}", recordCount, timer.Elapsed);
        }
        /// Get a new open connection
        private static SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
        private static IEnumerable<TransactionHistory> GetTransactions(int lastTransactionId, int count)
        {
            const string sql = "SELECT TOP(@count) [TransactionID],[TransactionDate],[TransactionType] FROM [Production].[TransactionHistory] WHERE [TransactionID] > @LastTransactionId ORDER BY [TransactionID]";
            return GetData<TransactionHistory>((connection) =>
                                                   {
                                                       SqlCommand command = new SqlCommand(sql, connection);
                                                       command.Parameters.AddWithValue("@count", count);
                                                       command.Parameters.AddWithValue("@LastTransactionId", lastTransactionId);
                                                       return command;
                                                   }, DataRecordToTransactionHistory);
        }
        // funtion to convert a data record to the TransactionHistory object
        private static TransactionHistory DataRecordToTransactionHistory(IDataRecord record)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.TransactionId = record.GetInt32(0);
            transactionHistory.TransactionDate = record.GetDateTime(1);
            transactionHistory.TransactionType = record.GetString(2);
            return transactionHistory;
        }
        private static IEnumerable<T> GetData<T>(Func<SqlConnection, SqlCommand> commandBuilder, Func<IDataRecord, T> dataFunc)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                using (SqlCommand command = commandBuilder(connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = dataFunc(reader);
                            yield return record;
                        }
                    }
                }
            }
        }
    }
    public class TransactionHistory
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
    }
