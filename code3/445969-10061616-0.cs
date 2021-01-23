    menuItem.Click += delegate {
    
    	Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input,
    		(Action)(() => { Shutdown(); }));
    
    };
