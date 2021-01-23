    public Form1()
    {
        this.InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        notifyIcon1.Icon = new Icon(@"C:\SomePath\MyIcon.ico");
        notifyIcon1.Visible = true;
        notifyIcon1.ShowBalloonTip(5000, "Welcome", "Hello " + User, ToolTipIcon.Info);
    }
