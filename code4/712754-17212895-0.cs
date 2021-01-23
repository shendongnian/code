        public static bool WaitForFileAvailable(string filePath, TimeSpan timeout)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed <= timeout)
            {
                Thread.Sleep(250);
                try
                {
                    return File.Exists(filePath);
                }
                catch 
                {  
                    // Not a very good thing to do, but I suppose that in the context of 
                    // the call from the FileSystemWatcher Created event could be allowed
                }
            }
            return false;
        }
