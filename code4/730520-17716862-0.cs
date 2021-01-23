    private void button1_Click(object sender, EventArgs e)
    {
          //Update label text here..
    
          BackgroundWorker _backgroundWorker = new BackgroundWorker();
          _backgroundWorker.DoWork += _backgroundWorker_DoWork;
          _backgroundWorker.RunWorkerAsync();
    }
    
    void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background,
                new Action(delegate()
            {
                //Download code here..
            }));
    }
