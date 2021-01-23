    SmartQueue smartQueue = new SmartQueue();
    public Form1()
    {
        InitializeComponent();
        smartQueue.ItemAdded += new SmartQueue.ItemAddedEventHandler(smartQueue_ItemAdded);
    }
    void smartQueue_ItemAdded(object sender, EventArgs e)
    {
        // add your code in here
    }
