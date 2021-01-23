    Timer t;
    public Form1()
    {
    	InitializeComponent();
    
    	t = new Timer();
    	t.Interval = 100;
    	t.Tick += new EventHandler(t_Tick);
    	t.Start();
    }
    
    void t_Tick(object sender, EventArgs e)
    {
    	string ticks = DateTime.Now.Ticks.ToString();
    	string ticks1 = ticks.Substring(ticks.Length-4),
    		ticks2 = ticks.Substring(ticks.Length - 5,4),
    		ticks3 = ticks.Substring(ticks.Length - 6,4);
    
    	batteryLabel1.Text = ticks1;
    	batteryLabel1.Text2 = ticks2;
    	batteryLabel1.Text3 = ticks3;
    	batteryLabel1.Battery1Fail = ticks1.StartsWith("1");
    	batteryLabel1.Battery2Fail = ticks2.StartsWith("1");
    	batteryLabel1.Battery3Fail = ticks3.StartsWith("1");
    }
