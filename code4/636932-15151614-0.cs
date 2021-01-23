    public void delay(string message) {
		var frame = new DispatcherFrame();
    	new Thread((ThreadStart)(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            frame.Continue = false;
        })).Start();
    Dispatcher.PushFrame(frame);
			actionReport.Text=message;
		}
