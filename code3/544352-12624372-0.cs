    private void btnTestSConnection_Click(object sender, EventArgs e)
            {
    			EventWaitHandle firstComplete = new EventWaitHandle(false, EventResetMode.ManualReset);
                EventWaitHandle secondComplete = new EventWaitHandle(false, EventResetMode.ManualReset);
    
    				bool overallResult = false;
    		
                BackgroundWorker work1 = new BackgroundWorker { WorkerSupportsCancellation = true };
                BackgroundWorker work2 = new BackgroundWorker { WorkerSupportsCancellation = true };
                work1.RunWorkerCompleted += (item, a) =>
                {
    				firstComplete.Set();
                    //need to figure out this portion
    				overallResult &= a.Result 
                };
                work2.RunWorkerCompleted += (item, a) =>
                {
    				secondComplete.Set();
                    //need to figure out this portion
    				overallResult &= a.Result 
                };
    
                work1.DoWork += doWork;
                work2.DoWork += doWork;
    
                SourceString.InitialCatalog = txtSSourceDatabase.Text;
                work1.RunWorkerAsync(SourceString.ConnectionString);
                SourceString.InitialCatalog = txtSSystemDatabase.Text;
                work2.RunWorkerAsync(SourceString.ConnectionString);
    			
    			// Wait on First will not go until set
                firstComplete.WaitOne();
    
                // Wait on second
                secondComplete.WaitOne();
    
                // Both now complete
    			//Do what you need to now
            }
    
    DoWorkEventHandler doWork = (sender, e) =>
            {
                SqlConnection Connection;
                BackgroundWorker worker = sender as BackgroundWorker;
                for (int i = 1; (i <= 10); i++)
                {
                        try
                        {
                            using (Connection = new SqlConnection((string)e.Argument))
                            {
                                Connection.Open();
                            }
                            e.Result = true;
                        }
                        catch (SqlException c)
                        {
                            e.Result = false;
                        }
                    }
            };
