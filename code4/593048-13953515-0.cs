    public partial class Splash : Window
    {
        private TypeBO boType = new TypeBO();
        private Stopwatch swTotal = new Stopwatch();
        private Stopwatch swData= new Stopwatch();
        public Splash()
        {
            InitializeComponent();
            swTotal.Start();
        }
        private void GetData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            lblMessage.Content = "Please Wait...";
            lblVersion.Content = "Version: " + assembly.GetName().Version.Major + "." + assembly.GetName().Version.Minor + "." + assembly.GetName().Version.Revision;
            swData.Start();
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += this.OnBackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }
        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            WEBAPI.GetHttpClient().GetAsync("api/COStateType/GetStateTypesByCountryID/"
                + Constants.COUNTRY_ID_USA).ContinueWith(r =>
                {
                    r.Result.EnsureSuccessStatusCode();
                    e.Result = r.Result.Content.ReadAsAsync<List<coStateType>>().Result;
                }).Wait();
            swData.Stop();
            System.Diagnostics.Debug.Write("Splash - DATA - Total Elapsed Time - " + swData.Elapsed + Environment.NewLine);
        }
        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;
            App.stateTypes = e.Result as List<coStateType>;
            coStateType pleaseSelectStateType = new coStateType() { State_ID = 0, State_Nm = "Select One", Country_ID = 1 };
            App.stateTypes.Insert(0, pleaseSelectStateType);
            sbHideState.Completed += (snd, eva) =>
            {
                //Pre-Load User Controls
                Assembly assembly = this.GetType().Assembly;
                UserControl ucBHSearch = (UserControl)assembly.CreateInstance(string.Format("{0}.BHSearch", "ABS2.WPF.ADMIN.UserControls.BusinessHierarchy"));
                UserControl ucBHDetails = (UserControl)assembly.CreateInstance(string.Format("{0}.BHDetails", "ABS2.WPF.ADMIN.UserControls.BusinessHierarchy"));
                App.userControls.Add("BHD", ucBHDetails);
                App.userControls.Add("BHS", ucBHSearch);
                Login winLogin = new Login();
                winLogin.Show();
                swTotal.Stop();
                System.Diagnostics.Debug.Write("Splash - UI - Total Elapsed Time - " + swTotal.Elapsed + Environment.NewLine + Environment.NewLine);
                swTotal.Reset();
                this.Close();
            };
            sbHideState.Begin(gridSplash);
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = "";
            lblVersion.Content = "";
            sbDefaultState.Begin(gridSplash);
            sbRotateState.Begin(gridSplash);           
        }
        private void window_ContentRendered(object sender, EventArgs e)
        {
            sbShowState.Completed += (snd, eva) =>
            {
                GetData();
            };
            sbShowState.Begin(gridSplash);
        }
    }
