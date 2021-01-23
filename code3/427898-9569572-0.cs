    public MainForm() {
        IsMdiContainer = true;
        InitializeComponent();
        this.MainMenuStrip = new MenuStrip(); // create our own menu strip
        this.MainMenuStrip.Visible = false;   
    }
