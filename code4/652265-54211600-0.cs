    public void WaitForTask(Task task)
    {
        DispatcherFrame frame = new DispatcherFrame();
        task.ContinueWith(t => frame.Continue = false));
        Dispatcher.PushFrame(frame);
    }
