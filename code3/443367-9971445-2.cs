    public void DoEvents()
    {
        DispatcherFrame frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Action<DispatcherFrame>)(frm => { frm.Continue = false; }), frame);
        Dispatcher.PushFrame(frame);
    }
