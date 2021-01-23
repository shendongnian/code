    private Storyboard stb = new Storyboard();
                
    public MainWindow()
    {
        InitializeComponent();
        stb.CurrentTimeInvalidated += new EventHandler(doSomething);            
    }
    
    private void doSomething(Object sender, EventArgs e)
    {
        Clock storyboardClock = (Clock)sender;
            // or whatever other logic you want
        if (storyboardClock.CurrentTime.Value.Seconds % 2 == 0)
        {
            // do something
        }
    }
