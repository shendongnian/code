    //Add a method to your view interface to show progress if you need it.
    public interface IView
    {
         void ShowProgress(int progressPercentage);
    }
    //Implement method in the view.
    public class MyView : Form, IView
    {
        public MyView()
        {
            //Assume you have added a ProgressBar to the form in designer.
            InitializeComponent();
        }
        public void ShowProgress(int progressPercentage)
        {
            //Make it thread safe.
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = progressPercentage; }));
            else
                progressBar1.Value = progressPercentage;
        }
    }
    // In your presenter class create a BackgroundWorker and handle it's do work event and put your time consuming method there.
    public class MyPresenter
    {
        private BackgroundWorker _bw;
        public MyPresenter()
        {
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
        }
        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Time consuming operation
            while (!finished)
            {
                //Do the job
                _bw.ReportProgress(jobProgressPercentage);
            }
        }
        public void StartTimeConsumingJob()
        {
            _bw.RunWorkerAsync();
        }
    }
