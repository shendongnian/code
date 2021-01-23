    public partial class Form1 : Form {
      private bool ok;
      private BackgroundWorker worker;
      public Form1() {
        InitializeComponent();
        worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;
        worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        ok = true;
      }
      private void timerTick(object sender, EventArgs e) {
        if (!worker.IsBusy) {
          worker.RunWorkerAsync();
        }
      }
      private void worker_DoWork(object sender, DoWorkEventArgs e) {
        var w = (BackgroundWorker)sender;
        MyData inputData = (MyData)e.Argument;
        for (int i = 0; (i < NUM_TASKS) && !worker.CancellationPending; i++) {
          w.ReportProgress(i);
          // do tasks
        }
        e.Result = SomethingYouWantReturned();
      }
      private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
        if (!ok) {
          worker.CancelAsync();
        }
      }
      private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        if (e.Error != null) {
          ok = false;
          MessageBox.Show(this, e.Error.Message, "Error!");
        } else {
          var item = (TypeYouWantedReturned)e.Result;
          Console.WriteLine("Do something with `item`.");
        }
      }
    }
