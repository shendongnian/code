    public Test(string Mode)
    {
       InitializeComponent();
       RunFirst_Settings();
       UserLogin login = new UserLogin();
       login.Hide();
       login.Visible = false;
       parentform = Mode;
    }
