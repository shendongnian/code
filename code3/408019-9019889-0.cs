    namespace CLT
    {
        public partial class GenBulkReceipts : UserControl
        {
            public void ProressBarMovement()
            {
                progressBar1.PerformStep();
            }
            public void LoadProgressBar(int progressbarMax)
            {
                progressBar1.Minimum = 1;
                progressBar1.Maximum = progressbarMax;
                progressBar1.Value = 1;
                progressBar1.Step = 1;
            }
            private void btnOpen_Click(object sender, EventArgs e)
            {
                try
               {
                   OpenFile();
                }
            }
            private void OpenFile()
            {
                if (dsEx1.Tables[0].Rows.Count > 0)
                {
                    AccountsToBeImported = new BLLService().Get_AccountsToBeReceipted(dsEx1);
                } 
            }
    }
    namespace BLL
    {
        class GenBulkReceiptsBLL
        {
			DataSet _dsImport;
            BackgroundWorker _backgroundWorker;
			CLT.GenBulkReceipts _pb;
            
            public GenBulkReceiptsBLL()
            {
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                _backgroundWorker.OnProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
                _backgroundWorker.ReportsProgress = true;
            }
            public DataSet Get_AccountsToBeReceipted(DataSet dsImport)
            {	
				_pb = new CLT.GenBulkReceipts();
				_pb.LoadProgressBar(dsImport.Tables[0].Rows.Count);
				_dsImport = dsImport;
			
                _backgroundWorker.RunWorkerAsync();  
            }
			
			public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
			{			
				int p = 0;	// set your progress if appropriate
				object param = "something"; // use this to pass any additional parameter back to the UI
					
				foreach (DataRow dr in _dsImport.Tables[0].Rows)
				{
					_backgroundWorker.ReportProgress(p, param);
				} 
            }
            // This event handler updates the UI
            private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
				_pb.ProressBarMovement();
            }
        }
    }
