    public ShellViewModel(
    	[NotNull] IWindowManager windows, 
    	[NotNull] IWindsorContainer container)
    {
    	if (windows == null) throw new ArgumentNullException("windows");
    	if (container == null) throw new ArgumentNullException("container");
    	_windows = windows;
    	_container = container;
    	UIDispatcher = Dispatcher.CurrentDispatcher; // not for WinForms
    }
    public Dispatcher UIDispatcher { get; private set; }
