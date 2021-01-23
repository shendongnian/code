    public partial class FrmFtpr : Form
    {
        private readonly ILog _log = LogManager.GetLogger("Ftp");
        private CancellationTokenSource  _cancellationTokenSource;
        private Task _task;
        private IEnumerable<FtpHost> GetFtpHost()
        {
          //get all ftp site info
            return ftpHost;
        }
       
        private async Task Upload(FtpHost ftpHost)
        {
            //upload files to a ftp
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_task != null && !_task.IsCompleted)
                return;
            var ftpTargets = GetFtpTargets().ToList();
            if (ftpTargets.Count == 0)
                return;
            _task = Task.Factory.StartNew(() =>
                {
                   var tasks = ftpTargets.Select(Upload).ToArray();
                    Task.WaitAll(tasks);
                });
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _log.Info(" Started");
            btnCancel.Enabled = true;
            btnStart.Enabled = false;
            timer1.Start();
        }
        private async void btnCancel_Click_1(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            _task.Wait();
            _log.Info(" Stoped");
            timer1.Stop();
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
        }
    }
