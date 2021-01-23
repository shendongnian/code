    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BeginWork();
        }
        private async void BeginWork()
        {
            while (true)
            {
                // Since we asynchronously wait, the UI thread is not blocked by the file download.
                var result = await DoWork(formTextField.Text);
                // Since we resume on the UI context, we can directly access UI elements.
                formTextField.Text = result;
            }
        }
        private async Task<string> DoWork(object text)
        {
            // Do actual work
            await Task.Delay(1000);
            // Return Actual Result
            return DateTime.Now.Ticks.ToString();
        }
    }
