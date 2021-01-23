        public MvcApplicationContext()
        {
            // Enable verification of transactions for ExecuteSQL functions.
            Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            // Disable lazy loading.
            Configuration.LazyLoadingEnabled = false;
            // Enable tracing of SQL queries.
            Database.Log = msg => Trace.WriteLine(msg);
            // Use MEF to compile a list of all sets within the context.
            ComposeSetsList();
        }
