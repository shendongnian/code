        // Main window initialization code 
        _argsField = typeof(DispatcherOperation).GetField("_args",
            BindingFlags.NonPublic | BindingFlags.Instance);
        Dispatcher.Hooks.OperationCompleted += Hooks_OperationCompleted;
    }
    FieldInfo _argsField;
    void Hooks_OperationCompleted(object sender, DispatcherHookEventArgs e) {
        if(e.Operation.Priority == System.Windows.Threading.DispatcherPriority.Loaded) {
            var source = _argsField.GetValue(e.Operation) as System.Windows.Interop.HwndSource;
            if(source != null) {
                Window w = source.RootVisual as Window;
                // ... here you can operate with newly created window
            }
        }
    }
