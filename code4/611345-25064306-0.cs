     public partial class ForceSyncWindow : Window
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
    
            public ForceSyncWindow()
            {
                InitializeComponent();
    
                ProgressBar1.Visibility = System.Windows.Visibility.Hidden;
    
                backgroundWorker.WorkerSupportsCancellation = true;
    
                // To report progress from the background worker we need to set this property
                backgroundWorker.WorkerReportsProgress = true;
    
                // This event will be raised on the worker thread when the worker starts
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
    
                // This event will be raised when we call ReportProgress
                backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
    
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            }
    
            void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // First, handle the case where an exception was thrown. 
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled  
                    // the operation. 
                    // Note that due to a race condition in  
                    // the DoWork event handler, the Cancelled 
                    // flag may not have been set, even though 
                    // CancelAsync was called.
                    ProgressBar1.Value = 0;
                    // TODO LOG  = "Canceled";
                 
                }
                else
                {
                    // Finally, handle the case where the operation  
                    // succeeded.
                    // TODO LOG e.Result.ToString();
                    
                }
    
                ProgressBar1.Value = 0;
                ProgressBar1.Visibility = System.Windows.Visibility.Hidden;
    
                // Enable the Synchronize button. 
                this.Synchronize.IsEnabled = true;
    
                // Disable the Cancel button.
                this.Cancel.IsEnabled = false;
            }
    
            // On worker thread so do our thing!
            void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                  // Your background task goes here
                    for (int i = 0; i <= 100; i++)
                    {
                        if (backgroundWorker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            // Perform a time consuming operation and report progress.
                            // Report progress to 'UI' thread
                            backgroundWorker.ReportProgress(i);
                            // Simulate long task
                            System.Threading.Thread.Sleep(100); ;
                        }                              
                    }            
            }
    
            // Back on the 'UI' thread so we can update the progress bar
            void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                // The progress percentage is a property of e
                ProgressBar1.Value = e.ProgressPercentage;
            }
    
            private void Synchronize_Click(object sender, RoutedEventArgs e)
            {
                ProgressBar1.Value = 0;
                ProgressBar1.Visibility = System.Windows.Visibility.Visible;
    
                // Disable the Synchronize button. 
                this.Synchronize.IsEnabled = false;
    
                // Enable the Cancel button.
                this.Cancel.IsEnabled = true;
    
                // Start the background worker
                backgroundWorker.RunWorkerAsync();
            }
    
            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                if (backgroundWorker.IsBusy)
                {
                    // Cancel the background worker
                    backgroundWorker.CancelAsync();
                }
            }
        }
