    private readonly SynchronizationContext _syncContext = SynchronizationContext.Current;
    private readonly TaskScheduler _scheduler = TaskScheduler.Current;
    
    void OnSomeEvent(object sender, EventArgs e)
    {
        if (_syncContext != SynchronizationContext.Current)
        {
            // Use Send if you need to get something done as soon as possible.
            // We'll be polite by using Post to wait our turn in the queue.
            _syncContext.Post(o => DoSomething(), null);
            return;
        }
        // Call directly if we are already on the UI thread
        DoSomething();
    }
    
    void OnSomeOtherEvent(object sender, MyEventArgs e)
    {
        var arg1 = e.Arg1; // "Hello "
        var arg2 = e.Arg2; // {"World", "!"};
        if (_scheduler != TaskScheduler.Current)
        {
            // Process args in the background, and then show the result to the user...
            Task<string>.Factory.StartNew(() => ReturnSomething(arg1, arg2))
                .ContinueWith(t => MessageBox.Show(t.Result), _scheduler);
            return;
        }
        
        // or don't bother with any background processing
        var msg = ReturnSomething(arg1, arg2);
        MessageBox.Show(msg);
    }
    void DoSomething() { MessageBox.Show("Hello World!"); }
    
    string ReturnSomething(string s, IEnumerable<string> list)
    {
        return s + list.Aggregate((c, n) => c + n);
    }
