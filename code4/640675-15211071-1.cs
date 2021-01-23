    public void Setup()
    {
        BackgroundWorker worker = new BackgroundWorker();
        // ...
        var handler = new RedirectableDoWorkEventHandler(handler1);
        worker.DoWork += handler.DoWork;
        // And then some time later...
        handler.Handler = handler2; // Now DoWork will call handler2.
    }
    private void handler1(object sender, DoWorkEventArgs e)
    {
        // Whatever
    }
    private void handler2(object sender, DoWorkEventArgs e)
    {
        // Whatever
    }
