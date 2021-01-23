    public partial class Form1 : Form
    {
        CancellationTokenSource _cancellationSource;
        int _currentRecord;
        int _maxRecord;
        public Form1()
        {
            InitializeComponent();
            _currentRecord = 0;
            _maxRecord = 5000;
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            await StartQueriesAsync();
        }
        private async Task StartQueriesAsync()
        {
            _cancellationSource = new CancellationTokenSource();
            var sw = new Stopwatch();
            
            try
            {
                // for Progress<>, include the code that outputs progress to your UI
                var progress = new Progress<int>(x => lblResults.Text = x.ToString());
                sw.Start();
                // kick off an async task to process your records
                await Task.Run(() => LoadResults(_cancellationSource.Token, progress));
            }
            catch (OperationCanceledException)
            {
                // stop button was clicked
            }
            
            sw.Stop();
            lblResults.Text = string.Format(
                "Elapsed milliseconds: {0}", sw.ElapsedMilliseconds);
        }
        private void LoadResults(CancellationToken ct, IProgress<int> progress)
        {
            while(_currentRecord < _maxRecord)
            {
                // watch for the Stop button getting pressed
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                // optionally call this to display current progress
                progress.Report(_currentRecord);
                // simulate the work here
                Thread.Sleep(500);
                _currentRecord++;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancellationSource.Cancel();
        }
    }
