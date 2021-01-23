    class SqlHelper : IDisposable
    {
        public SqlHelper(string connectionString, string query) { ... }
        public SqlConnection { get; set; }
        public SqlCommand { get; set; }
        // SQL querying logic here
        public void Execute() { ... }
        /** IDisposable implementation **/
    }
