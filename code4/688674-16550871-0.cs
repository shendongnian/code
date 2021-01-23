    private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Visible = false;
            theBackgroundWorker.DoWork += new DoWorkEventHandler(theBackgroundWorker_doYourWork);      
            theBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(theBackgroundWorker_ProgressChanged);
            theBackgroundWorker.RunWorkerAsync();        
  
        }
        void theBackgroundWorker_doYourWork(object sender, DoWorkEventArgs e)
        {
             var w = sender as BackgroundWorker;
             
             List<String> stringList = GenerateComplimentTexts();
             Thread.Sleep(2000);
             w.ReportProgress(0, "Happy Birthday Goose!!!");
             w.ReportProgress(1, "Happy Birthday Goose!");      
             Thread.Sleep(3000);
             w.ReportProgress(2, "You are...");    
             Thread.Sleep(2000);
             foreach (String e in stringList)
             {
                 w.ReportProgress(3, e);                
                 Thread.Sleep(1000);
             }
             Thread.Sleep(3000);
             w.ReportProgress(3, "");  
             w.ReportProgress(2, FinalMessage);
        }
        void theBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var msg = e.UserState.ToString();
            switch (e.ProgressPercentage)
            { 
                case 0:
                     form.Text = msg;
                     break;
                case 1:
                    hBDLabel.Text=msg;
                    break;
                case 2:
                    youAreLabel.Text =msg;
                    break;
                case 3:
                    mainLabel.Text=msg;
                    break;
                    
            }        
        }
     
