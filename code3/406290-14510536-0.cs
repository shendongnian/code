    // code assumes dispatcherTimer, _process and _isPrompt are declared on the WFP form
    this.dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    this.dispatcherTimer.Tick += (sender, e) =>
    {
        this._isPrompt = proc
            .Threads
            .Cast<ProcessThread>()
            .Any(t => t.WaitReason == ThreadWaitReason.UserRequest);
    };
    this.dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
    this.dispatcherTimer.Start();
    ...
    this._process.Start();
