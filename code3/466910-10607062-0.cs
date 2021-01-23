    var interval = new TimeSpan( 0, 0, 1 );
    const string isWin32Process = "TargetInstance isa \"Win32_Process\"";
    // Listen for started processes.
    WqlEventQuery startQuery
        = new WqlEventQuery( "__InstanceCreationEvent", interval, isWin32Process );
    _startWatcher = new ManagementEventWatcher( startQuery );
    _startWatcher.Start();
    _startWatcher.EventArrived += OnStartEventArrived;
    
    // Listen for closed processes.
    WqlEventQuery stopQuery
        = new WqlEventQuery( "__InstanceDeletionEvent", interval, isWin32Process );
    _stopWatcher = new ManagementEventWatcher( stopQuery );
    _stopWatcher.Start();
    _stopWatcher.EventArrived += OnStopEventArrived;
