    public partial class App : Application
    {
        LoadingScreen LS;   
        public void Main()
        {
            System.ComponentModel.BackgroundWorker BW;
            BW.DoWork += BW_DoWork;
            BW.RunWorkerCompleted += BW_RunWorkerCompleted;
            LS = new LoadingScreen();
            LS.Show();
        }
        
        private void BW_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Do here anything you have to do with the database
        }
        void BW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            LS.Close();
        }
    }
