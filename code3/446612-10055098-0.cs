    public partial class MainForm: Form
    {
      private void btnImport_Click(object sender, EventArgs e) {
        var waitingForm = new WaitingForm();
        waitingForm.Show();
        var worker = new BackgroundWorker();
        worker.DoWork += (o, args) => this.LogRunningOperation(o, args);
        worker.OnWorkComplete += (o, args) => {
          waitingForm.Close();
          worker.Dispose();
        };
        worker.RunWorkerAsync();
        
        private void LongRunningOperation(object sender, DoWorkEventArgs e) {
          MessageBox.Show("Running long operation!....");
          // some long running stuff here;
        }
    }
