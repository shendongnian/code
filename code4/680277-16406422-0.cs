        private readonly Semaphore semLock = new Semaphore(1, 1);
        void AThread()
        {
            semLock.WaitOne();
            try {
                // Protected code
            }
            finally {
                semLock.Release();
            }
            // Unprotected code
        }
