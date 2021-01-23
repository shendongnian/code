    public class Scanner
    {
        private static _syncRoot = new object();
        public Scanner(string host)
        {
            Host = host;
            StartScanning();
        }
        public string Host {get; private set; }
        public bool IsScanning {get; private set; }
        public void StartScanning()
        {
            lock(_syncRoot)
            {
                if (!IsScanning)
                {
                    IsScanning = true;
                    // Start scanning Host asynchronously
                    ...
                }
            }
        }
        private void EndScanning()
        {
            // Called when asynchronous scanning has completed
            IsScanning = false;
        }
    }
