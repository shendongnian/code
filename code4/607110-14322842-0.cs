    private static List<string> MessageQueue = new List<string>();
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DispatcherTimer messageQueueTimer = new DispatcherTimer();
        messageQueueTimer.Tick += messageQueueTimer_Elapsed;
        messageQueueTimer.Interval = new TimeSpan(1); //1 tick
        messageQueueTimer.Start();
    }
    protected void messageQueueTimer_Elapsed(object sender, EventArgs e)
    {
        lock(MessageQueue)
        {
            //Read message from queue and remove it.
        }
    }
    //WriteLine can be called from any asyncronous method spawed from the UI.
    public void WriteLine(string message)
    {
        lock(MessageQueue)
        {
            //Insert message into the queue.        
        }
    }
