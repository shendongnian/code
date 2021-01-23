            private Timer dispatcher;
    
            public MainView()
            {
                InitializeComponent();
                frmMdiChildList = new List<Form>();
                Load += new EventHandler(MainView_Load);
                FormClosing += new FormClosingEventHandler(MainView_FormClosing);
                Activated += new EventHandler(MainView_Activated);
                
            }
    
            void MainView_Load(object sender, EventArgs e)
            {
                dispatcher = new Timer();
                dispatcher.Interval = 10; //10 milliseconds
                dispatcher.Tick += new EventHandler(dispatcher_Tick);
                dispatcher.Start();
            }
    
            void dispatcher_Tick(object sender, EventArgs e)
            {
                dispatcher.Stop();
                dispatcher = null;
                showLoginForm();
            }
    
            private void showLoginForm() {
                Form loginForm = new LoginView();
                loginForm.ShowDialog();
            }
