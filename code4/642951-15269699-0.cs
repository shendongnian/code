    private MainWindow switchPage;
    public MainMenu(MainWindow mainP)
    {
        InitializeComponent();
        switchPage = mainP;
    }
    private void btn_navigate_user(object sender, EventArgs e)
    {
        UserPage userP = new UserPage(ServiceLogic);
        switchP.LoadAPage(userP);
    }
