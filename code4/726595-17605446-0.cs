        private static ReaderWriterLock lockObject = new ReaderWriterLock();
        public static void Invalidate()
        {
            try
            {
                lockObject.AcquireWriterLock(LockTimeoutMilliseconds);
                try
                {
                    // Invalidate your content and reload here
                }
                finally
                {
                    lockObject.ReleaseLock();
                }
            }
            catch (ApplicationException ex)
            {
                // The reader lock request timed out. Log this.
            }
        }
