    public partial class BackgroundWorkerPage : Page
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        public BackgroundWorkerPage()
        {
            InitializeComponent();
            _worker.DoWork += WorkerOnDoWork;
            _worker.WorkerReportsProgress = true;
            _worker.ProgressChanged += WorkerOnProgressChanged;
        }
        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            progressBar.Value = progressChangedEventArgs.ProgressPercentage;
        }
        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                _worker.ReportProgress(i);
            }
        }
        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            _worker.RunWorkerAsync();
        }
    }
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <ProgressBar x:Name="progressBar" Height="23" Minimum="0" Maximum="100"/>
        <Button Grid.Row="1" Height="23" Content="Start" Click="Button_Click_1"/>
    </Grid>
