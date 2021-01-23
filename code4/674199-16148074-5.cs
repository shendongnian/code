    public MyControl()
    {
        InitializeComponent();
        Application.AddMessageFilter(new MessageHandler(GetChildWindows(this.Handle)));
    }
