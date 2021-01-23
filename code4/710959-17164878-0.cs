    var bw = new BackgroundWorker();            
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompleted);
    bw.DoWork += new DoWorkEventHandler(DoWork);
    bw.RunWorkerAsync(data);  //assume data is list of numbers
    private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)  //after work completed remove event handlers and dispose
    {
        var bw = (BackgroundWorker)sender;
        bw.RunWorkerCompleted -= WorkCompleted;
        bw.DoWork -= DoWork;
        bw.Dispose();
    }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        var data = (List<int>)e.Argument;
    
        foreach (var number in data)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke((MethodInvoker)delegate { this.ProcessNumber(number); });                    
            }
            else
            {
                ProcessNumber(number);
            }
        }
    }
    
    private void ProcessNumber(int i)
    {
        progressBar1.PerformStep();
        
        //do something with i
    }
