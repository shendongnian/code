    // In the FileUpload Event Handler, or other Event Handler raised to start the process
    ThreadPool.QueueUserWorkItem(new WaitCallback(DataLoader.InsertClientRecords), new Tuple<string, Guid>("PathToFile.csv", uniqueIdentifier));
    // In the Ajax callback (or WebMethod as previously proposed) to update the UI, possible update a GridView with results etc.
    List<Tuple<Guid, int, bool, string>> updates = DataLoader.GetProgressReports(uniqueIdentifier);
    // Static class
    public static class DataLoader
    {
        private static readonly object locker = new object();
        // Tuple Guid for unique Identifier, int RowNumber, bool Result, string Message (if any)
        private static List<Tuple<Guid, int, bool, string>> results = new List<Tuple<Guid, int, bool, string>>();
        public static void InsertClientRecords(object stateInfo)
        {
            // string FilePath, Guid for unique Identifier
            Tuple<string, Guid> recordInfo = stateInfo as Tuple<string, Guid>;  
          
            if (recordInfo != null)
            {
                string filePath = recordInfo.item1;
                Guid id = recordInfo.item1;
                lock (locker)
                {
                    // Update results List
                }            
            }
        }
        // Tuple Guid for unique Identifier, int RowNumber, bool Result, string Message (if any)
        public static List<Tuple<Guid, int, bool, string>> GetProgressReports(Guid identifier)
        {
            List<Tuple<Guid, int, bool, string>> updatedRecords = null; 
            bool lockTaken = false;
            try
            {
                // 1000 Millisecond Timeout so the Ajax callback does not hang.
                Monitor.TryEnter(locker, 1000, ref lockTaken);
                if (lockTaken)
                {
                    updatedRecords = results.Where(r => (r.Item1 == identifier)).ToList();
                    if (updatedRecords != null)
                        DataLoader.results.RemoveAll(r => (r.Item1 == identifier));
                }
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(locker);
            }  
            
            return updatedRecords;
        }         
