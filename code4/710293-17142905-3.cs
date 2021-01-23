    public partial class Form1 : Form
    {
        private readonly Timer _sampleTimer;
 
        public Form1()
        {
            InitializeComponent();
            _sampleTimer = new Timer
                {
                    Interval = 500 // 0.5 Seconds
                };
            _sampleTimer.Tick += DoWorkAndUpdateUIAsync;
        }
        private async void DoWorkAndUpdateUIAsync(object sender, EventArgs e)
        {
            // Since we asynchronously wait, the UI thread is not blocked by "the work".
            var result = await DoWorkAsync();
            // Since we resume on the UI context, we can directly access UI elements.
            resultTextField.Text = result;
        }
        private async Task<string> DoWorkAsync()
        {
            await Task.Delay(1000); // Do actual work sampling usb async (not blocking ui)
            return DateTime.Now.Ticks.ToString(); // Sample Result
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            _sampleTimer.Start();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            _sampleTimer.Stop();
        }
    }
 
