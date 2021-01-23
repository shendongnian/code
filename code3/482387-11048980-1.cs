    public bool? ShowDialog(Dialog dialog)
    {
        // This will hold the result returned by the dialog
        bool? result = null;
        // We show a dialog using the method that returns an IObservable
        var subject = this.Show(dialog);
        // but we have to wait for it to close on another thread, otherwise we'll block the UI
        // we do this by preparing  a new DispatcherFrame that exits when we get a value
        // back from the dialog
        DispatcherFrame frame = new DispatcherFrame();
        // So start observing on a new thread. The Start method will return immediately.
        new Thread((ThreadStart)(() =>
        {
            // This line will block on the new thread until the subject sends an OnNext or an OnComplete
            result = subject.FirstOrDefault();
            // once we get the result from the dialog, we can tell the frame to stop
            frame.Continue = false;
        })).Start();
        // This gets executed immediately after Thread.Start
        // The Dispatcher will now wait for the frame to stop before continuing
        // but since we are not blocking the current frame, the UI is still responsive
        Dispatcher.PushFrame(frame);
        return result;
    }
