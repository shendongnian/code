          public MainPage()
        {
            InitializeComponent();
    
            UserControl1.CreateNewUserControl += UserControl1_CreateNewUserControl;
        }
        void UserControl1_CreateNewUserControl(object sender, EventArgs e)
        {
            if(UserControlTest != null)
            {
                var control = new UserControl1();
                control.CreateNewUserControl += UserControl1_CreateNewUserControl;
                UserControlTest.Children.Add(control);
            }
        }
