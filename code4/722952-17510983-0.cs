    public Form1()
    {
        InitializeComponent();
        this.listOverdueParameter1.ButtonClickEvent += new EventHandler(UserControl_ButtonClick);
    }
    private void UserControl_ButtonClick(object sender, EventArgs e)
    {
        //sample event stuff
        this.Close();
        Form2 F2 = new Form2();
        F2.Show();
    }
