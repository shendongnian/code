    public interface IUiDispatcher
    {
        Dispatcher Dispatcher { get; }
    }
    public class UiDispatcher : IUiDispatcher
    {
        public UiDispatcher()
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA
                && !Thread.CurrentThread.IsBackground
                && !Thread.CurrentThread.IsThreadPoolThread)
            {
                this.Dispatcher = Dispatcher.CurrentDispatcher;
            }
            else
            {
                throw new InvalidOperationException("Ui Dispatcher must be created in UI thread");
            }
        }
        public Dispatcher Dispatcher { get; set; }
    }
    public class ExecutedOnABackgroundThread
    {
        IUiDispatcher uidispatcher;
        public ExecutedOnABackgroundThread(IUiDispatcher uidispatcher)
        {
            this.uidispatcher = uidispatcher;
        }
        public void Method()
        {
            // Do something on the background thread...
            // ...
            // Now we need to do something on the UI
            this.uidispatcher.Dispatcher.BeginInvoke(new Action(delegate
            {
                // Do something
            }), null);
        }
    }
