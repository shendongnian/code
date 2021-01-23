            /// <summary>
            /// The BackgroundWorker to handle you async work
            /// </summary>
            BackgroundWorker bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
    
            /// <summary>
            /// Handles the Click event of the btnStart control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void btnStart_Click(object sender, EventArgs e)
            {
                if (bw.IsBusy)
                {
                    return;
                }
    
                System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
                bw.DoWork += (bwSender, bwArg) =>
                {
                    //what happens here must not touch the form
                    //as it's in a different thread        
                    sWatch.Start();
    
                   
                    var _child = new Thread(() =>
                    {
                        this.LoadResults();
    
                    });
                    _child.Start();
                    while (_child.IsAlive)
                    {
                        if (bw.CancellationPending)
                        {
                            _child.Abort();
                            bwArg.Cancel = true;
                        }
                        Thread.SpinWait(1);
                    }                
                    
                };
    
                bw.ProgressChanged += (bwSender, bwArg) =>
                {
                    //update progress bars here
                };
    
                bw.RunWorkerCompleted += (bwSender, bwArg) =>
                {
                    //now you're back in the UI thread you can update the form
                    //remember to dispose of bw now               
    
                    sWatch.Stop();
                    MessageBox.Show(String.Format("Thread ran for {0} milliseconds",sWatch.ElapsedMilliseconds));
                    //work is done, no need for the stop button now...
                    this.btnStop.Enabled = false;
                    bw.Dispose();
                };
    
                //lets allow the user to click stop
                this.btnStop.Enabled = true;
                //Starts the actual work - triggerrs the "DoWork" event
                bw.RunWorkerAsync();
               
           
            }
    
            /// <summary>
            /// Handles the Click event of the btnStop control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void btnStop_Click(object sender, EventArgs e)
            {
                //Stop the running thread
                this.bw.CancelAsync();
                // Need to display the time between the thread start and stop.
            }
    
            private void LoadResults()
            {
                //Simulation job time...
                Thread.Sleep(5000);
            } 
