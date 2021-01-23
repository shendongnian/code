    class SqlHelper : IDisposable
    {
        public SqlHelper(string connectionString, string query) { ... }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        // SQL querying logic here
        public void Execute() { ... }
        /** IDisposable implementation **/
    }
