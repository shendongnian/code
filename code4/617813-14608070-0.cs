        static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame(true);
            Dispatcher.CurrentDispatcher.BeginInvoke
            (DispatcherPriority.Background, (SendOrPostCallback) delegate(object arg)
            {
                var f = arg as DispatcherFrame; 
                f.Continue = false;
            }, 
            frame);
            Dispatcher.PushFrame(frame);
        } 
