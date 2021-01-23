    public MyWindow()
    {
        InitializeComponent();
        this.Closing += new System.ComponentModel.CancelEventHandler(MyWindow_Closing);
    }
    void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    }
