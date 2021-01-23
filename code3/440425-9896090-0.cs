    private static ConcurrentQueue<Tuple<Exception, DateTime>> QueuedErrors = new ConcurrentQueue<Tuple<Exception, DateTime>>();
    private static Object Lock_HandleError = new Object();
    public static void HandleError(Exception ex, string extraInfo = "", bool showMsgBox = true, bool resetApplication = true)
    {
        QueuedErrors.Enqueue(new Tuple<Exception, String>(ex, DateTime.Now));
        ThreadPool.QueueUserWorkItem(()=>((App)App.Current).Dispatcher.Invoke((Action)
                () => {
                    lock (Lock_HandleError)
                        Tuple<Exception, DateTime> currentEx;
                        while (QueuedErrors.TryDequeue(out currentEx))
                            MessageBox.Show(
                               currentEx.Item1, // The exception
                               "MUS Application Error", 
                               MessageBoxButton.OK, 
                               MessageBoxImage.Error);
                }))
        );
