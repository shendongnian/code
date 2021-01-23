    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnStartJob_Click(object sender, EventArgs e)
        {
            Thread backgroundThread = new Thread
            (
                () =>
                {
                    var job = new BackgroundJob();
                    job.StepCompleted += job_StepCompleted;
                    job.Execute();
                }
            );
            backgroundThread.Start();
        }
        private void job_StepCompleted(object sender, int percentage)
        {
            progressBar.Percentage = percentage;
            progressBar.Invalidate();
        }
    }
