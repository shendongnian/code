        public void SetCommandLineInThread(string[] args) {
            new Thread(() => {
                SetCommandLine(args);
            }) { IsBackground = true, Priority = ThreadPriority.Lowest }.Start();
        }
