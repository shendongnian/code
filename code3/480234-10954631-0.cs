    public partial class SplashScreen : Form
    {    
        bool DATABASE_CONNECTION;
        bool RegisteredUser; // if user has been registered
        string USER_NAME;
        string PASSWORD;
        Register Register;
        DialogResult result;
        Timer opac = new Timer();
        BackgroundWorker bw = new BackgroundWorker();
        public SplashScreen()
        {
            InitializeComponent(); // initalize splash screen
            DatabaseStatus(); // set database connection
            getUserInfo(); // get user information
            showInfo(); // show app information on splash screen
       
            bw.WorkerSupportsCancellation = false;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(checkUser);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.richTextBox1.Text += e.UserState;
        } 
        void checkUser(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            System.Threading.Thread.Sleep(1000);
            worker.ReportProgress(0, "Checking for user information...");
     
            if (RegisteredUser)
            {
                System.Threading.Thread.Sleep(1000);
                worker.ReportProgress(0,"User registered...");
                if (DATABASE_CONNECTION)
                {
                    System.Threading.Thread.Sleep(1000);
                    worker.ReportProgress(0,"Database connection O.K.");
                    LoginCheck login = new LoginCheck(USER_NAME, PASSWORD);
                    if (login.LOGIN_SUCESS)
                    {
                        System.Threading.Thread.Sleep(1000);
                        worker.ReportProgress(0,"Logged in success");
                        // start fadin form out with custom method...
                        opac.Interval = 12; 
                        opac.Start();
                        opac.Tick += new EventHandler(dec);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                        worker.ReportProgress(0,"Log in not successful");
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    worker.ReportProgress(0, "No database connection");
                }
            }
            else
            {
                worker.ReportProgress(0,"No user found");
                result = MessageBox.Show("Do you want to register?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Register = new Register();
                    Register.ShowDialog();
                }
            }
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
    }
