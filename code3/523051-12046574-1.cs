        public void RestartServices()
        {
            //Write
            // Want to WriteProgress here...
            for (int i = 0; i <= 100; i += 10)
            {
                Console.WriteLine("i is " + i);
                UpdateProgress(i);
                Thread.Sleep(500);
            }
        }
        private void UpdateProgress(int percentComplete)
        {
            var runspace = Runspace.DefaultRunspace;
            var pipeline = runspace.CreateNestedPipeline("Write-Progress -Act foo -status bar -percentComplete " + percentComplete, false);
            pipeline.Invoke();
        }
