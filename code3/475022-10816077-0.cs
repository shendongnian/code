      public MainForm()
      {
        InitializeComponent();
        this.Visible = false;
        //Showing welcome box
        welcomeBox = new GUI.WelcomeBox();
        welcomeBox.Visible = true;
        this.Visible = false;
        timer = new System.Threading.Timer(new System.Threading.TimerCallback(delayedActions),null,5000,2000);
