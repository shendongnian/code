    public Form1()
    {
      InitializeComponent();
      this.searchProgressTimer = new System.Windows.Forms.Timer();
      this.searchProgressTimer.Interval = 250;
      this.searchProgressTimer.Tick += new EventHandler(searchProgressTimer_Tick);
    }
