    public MainWindow() {
        InitializeComponent();
        foreach (Control item in menu1.Items) item.IsTabStop = false;
        menu1.PreviewGotKeyboardFocus += delegate { foreach (Control item in menu1.Items) item.IsTabStop = true; };
        menu1.PreviewLostKeyboardFocus += delegate { foreach(Control item in menu1.Items) item.IsTabStop = false; };
    }
