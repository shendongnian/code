    public Form1()
    {
        InitializeComponent();
        
        loadlogin();
    }
    private void loadlogin()
    {
        login log = new login();
        //Registers the UserControl event
        log.changeParentTextWithCustomEvent += new EventHandler<TextChangedEventArgs>(log_changeParentTextWithCustomEvent);
        mainPannel.Controls.Clear();
        mainPannel.Controls.Add(log);
    }
    private void log_changeParentTextWithCustomEvent(object sender, TextChangedEventArgs e)
    {
        this.Text = e.Text;
    }
    
