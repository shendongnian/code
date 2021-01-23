    private SynchronizationContext _syncContext = null;
    
    public Form1()
    {
        InitializeComponent();
    
        //get hold of the sync context
        _syncContext = SynchronizationContext.Current;
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        //queue a call to MyMethod on a threadpool thread
        ThreadPool.QueueUserWorkItem(x => MyMethod());
    }
    
    private void MyMethod()
    {
        //do work...
    
        //before exiting, call UpdateGui on the gui thread
        _syncContext.Post(
            new SendOrPostCallback(
                delegate(object state)
                {
                    UpdateGui();
                }), null);
    }
    
    private void UpdateGui()
    {
        MessageBox.Show("hello from the GUI thread");
    }
