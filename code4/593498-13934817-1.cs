    public void Function()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += TimeConsumingFunction;
        var frame = new DispatcherFrame();
        worker.RunWorkerCompleted += (sender, args) =>
                                         {
                                             frame.Continue = false;
                                         };
        worker.RunWorkerAsync();
        Dispatcher.PushFrame(frame);
    }
    private void TimeConsumingFunction(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        Console.WriteLine("Entering");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(1000);
        }
        Console.WriteLine("Exiting");
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Function();
        Console.WriteLine("Returns");
    }
