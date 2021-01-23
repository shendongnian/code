    public MainWindow()
    {
        InitializeComponent();
        this.OtherUserControl.ButtonClicked += OtherUserControl_ButtonClicked;
    }
    void OtherUserControl_ButtonClicked(object sender, EventArgs e)
    {
        this.MyUserControl.TextValue.Text = "Updated Text";
    }
