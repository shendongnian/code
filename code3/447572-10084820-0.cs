    private System.Windows.Forms.Timer _timer;
    protected override void OnLoad(EventArgs args)
    {
        _timer = new Timer { Interval = 1 };
        _timer.Tick += (s, e) => new Thread(CloseForm).Start();
        _timer.Start();
    
        base.OnLoad(args);
    }
