    private SynchronizationContext _synchronizationContext;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        // Capture the context.
        _synchronizationContext = SynchronizationContext.Current;
    
        // Rest of code.
        ...
    }
