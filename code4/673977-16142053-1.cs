    private BackgroundWorker _bw;
     
    ....
        InitializeComponent();
        _bw = new BackgroundWorker
        {
          WorkerReportsProgress = true,
          WorkerSupportsCancellation = true
        };
        _bw.DoWork += bw_DoWork;
        _bw.ProgressChanged += bw_ProgressChanged;
        _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
     
        _bw.RunWorkerAsync ("Hello to worker");
         if (_bw.IsBusy) _bw.CancelAsync();
      }
     
      private void bw_DoWork (object sender, DoWorkEventArgs e)
      {
            
          if (_bw.CancellationPending) { e.Cancel = true; return; }
          var dataPoints = YourConnectToSerialPortAndGetDataFunction();
          _bw.ReportProgress (dataPoints);
          Thread.Sleep (1000); 
     
        e.Result = dataPoints;    // This gets passed to RunWorkerCompleted
      }
     
      private void bw_RunWorkerCompleted (object sender,
                                         RunWorkerCompletedEventArgs e)
      {
          
    }
     
      private void bw_ProgressChanged (object sender,
                                      ProgressChangedEventArgs e)
      {
    //UPDATE YOUR LABEL
    chart1.Series["Temperature"].Points.AddXY(0, 20);
            chart1.Series["Temperature"].Points.AddXY(1, 50);
      }
