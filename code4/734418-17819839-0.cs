        private BackgroundWorker worker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            //Register the event/handlers for: Do Work, ProgressChanged, and Worker Completed.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork); 
            worker.WorkerReportsProgress = true; //Let's tell the worker that it WILL be ABLE to report progress.
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged); //Method that will be called when the progress has been changed.            
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted); //Method that will be called when the thread finish executing.
            //Start the thread async.
            worker.RunWorkerAsync();
        }
        /// <summary>
        /// Method that will run in a new thread async from the main thread.
        /// </summary>        
        /// <param name="e">Arguments that are passed to the Worker Thread (a file, path, or whatever)</param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get the argument. In this example I'm passing a pathFile.
            string pathFile = (string)e.Argument;
            
            for (int i = 0; i <= 100; i+=10) //For demonstration purposes we're running from 0 to 99;
            {
                System.Threading.Thread.Sleep(100); //Sleep for demonstration purposes.
                //I want to update the Log, so the user will be notified everytime
                //the log is updated through the ReportProgress event.
                string myLog = i + " ";
                //Invoke the event to report progress, passing as parameter the
                //percentage (i) and the current log the thread has modified.
                worker.ReportProgress(i, myLog);
            }            
            
            e.Result = "I've made it!!!!! - My complex cientific calculation from NASA is 654.123.Kamehameha)";
        }        
        /// <summary>
        /// Invoked when the worker calls the ReportProgress method.
        /// </summary>        
        /// <param name="e">The arguments that were passed throgh the ReportProgress method</param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Get the Percentage and update the progressbar.
            progressBar1.Value = e.ProgressPercentage;
            //Get the EventArgs and respectively the new log that the thread has modified and append it to the textbox.
            textBox1.AppendText((string)e.UserState);
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Lets check whether the worker has runned successfully (without cancelling and without any errors)
            if (!e.Cancelled && e.Error == null)
            {
                //Lets display the result (Result is an object, so it can return an entire class or any type of data)
                MessageBox.Show((string)e.Result);
            }
        }
