    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private FirstTask firstTask;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BackgroundWorker backWorker = new BackgroundWorker();
            backWorker.DoWork += new DoWorkEventHandler(backWorker_DoWork);
            backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorker_RunWorkerCompleted);
            backWorker.RunWorkerAsync();
            MainWindow mainWindow = new MainWindow();
            firstTask = new FirstTask();
            firstTask.ShowDialog();
            mainWindow.Show();
        }
        void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            firstTask.Close();
        }
        void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
