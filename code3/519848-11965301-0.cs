     private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the form's BackgroundWorker reference directly.
            // Instead use the reference provided by the sender parameter
            BackgroundWorker bw = sender as BackgroundWorker;
            // Extract the argument
            RequestEntity arg = (RequestEntity)e.Argument;
            // Start the time consuming operation
            Poll poll = new Poll();
            e.Result = poll.pollandgetresult(bw, arg);
            // If operation was cancelled by user
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
