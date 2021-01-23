    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RegisteredUser = true;
            DATABASE_CONNECTION = true;
            
        }
        private void UpdateStatus(string message)
        {
            BeginInvoke(new MethodInvoker(() => richTextBox1.Text += message));
        }
        private void CheckUser()
        {
            if (RegisteredUser)
            {
                UpdateStatus("Loading user settings..."); // SHOW THIS TEXT AND WAIT 1 SECOND UNTIL NEXT
                System.Threading.Thread.Sleep(1000);
                if (DATABASE_CONNECTION)
                {
                    UpdateStatus("Logging on...");
                    //// WAIT AGAIN 1 SEC AND CONTINUE///
                    //LoginCheck login = new LoginCheck(USER_NAME, PASSWORD);
                    if (true)//login.LOGIN_SUCESS)
                    {
                        UpdateStatus("Success!");
                        // SHOW THIS TEXT AND WAIT 1 SEC UNTIL SPLASH SCREEN FADE OUT//
                        //MessageBox.Show(login.HASH);
                        //opac.Interval = 12;
                        //opac.Start();
                        //opac.Tick += new EventHandler(dec);
                    }
                    else
                    {
                        //MessageBox.Show(login.HASH);
                    }
                }
            }
            else
            {
                UpdateStatus("No user profile found.");
                // ask user to register
            }
        }
        protected bool DATABASE_CONNECTION { get; set; }
        protected bool RegisteredUser { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            var invoker = new MethodInvoker(CheckUser);
            invoker.BeginInvoke(null, null);
        }
    }
