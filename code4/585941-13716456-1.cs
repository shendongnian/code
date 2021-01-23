        private void StartProcessing()
        {
            System.Threading.Thread procThread = new System.Threading.Thread(this.Process);
            procThread.Start();
        }
        private void Process() // this is the actual method of the thread
        {
            foreach (System.IO.FileInfo f in dir.GetFiles("*.txt"))
            {
                // Do processing
                // Show progress bar
                // Update Label on Form, "f.Name is done processing, now processing..."
                UpdateStatus("Processing " + f.Name + "...");                
            }
        }
