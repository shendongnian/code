    public partial class SplashScreen : Form
    {      
        bool DATABASE_CONNECTION;
        bool RegisteredUser; // if user has been registered
        string USER_NAME;
        string PASSWORD;
        double LIN_x = 0.01;
     
        DialogResult result;
        custom con = new custom();
        Timer opac = new Timer();
        public SplashScreen()
        {
            InitializeComponent(); // initalize splash screen
            DatabaseStatus(); // set database connection
            getUserInfo(); // get user information
            showInfo(); // show app information on splash screen
        }
        private void UpdateStatus(string message)
        {
            BeginInvoke(new MethodInvoker(() => richTextBox1.Text += message + Environment.NewLine));
        }
        void checkUser()
        {
            UpdateStatus("Loading user settings..."); 
            if (RegisteredUser)
            {
                UpdateStatus("User " + USER_NAME + " found." );
                if (DATABASE_CONNECTION)
                {
                    UpdateStatus("Logging on..."); 
                    LoginCheck login = new LoginCheck(USER_NAME, PASSWORD);
                    if (login.LOGIN_SUCESS)
                    {
                        UpdateStatus("Success! Loading " + con.AppTitle() + "...please wait");
                        //UpdateStatus(login.HASH); return hash string from web site
                        fadeSplash(); // begin fade out of form
                    }
                    else
                    {
                        UpdateStatus("There was an error logging in."); 
                    }
                }
                else
                {
                    UpdateStatus("No database connection found."); 
                }
            }
            else
            {
                UpdateStatus("No user found"); 
                Reg(); // Registration form
            }
        }
        private void fadeSplash()
        {
            opac.Interval = 12;
            opac.Tick += new EventHandler(dec);
            opac.Start();
        }
        private void dec(object sender, EventArgs e)
        {
            this.Opacity -= LIN_x;
            if (this.Opacity < 0.04)
            {
                opac.Stop();
                this.Hide();
                main open = new main(); // start application
                open.Show();
            }
        }
    }
