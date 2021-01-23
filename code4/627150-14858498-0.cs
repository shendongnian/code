    public class Foo
    {
        public event Action MyEvent;
        public void FireEvent()
        {
            Action myevent = MyEvent;
            if (myevent != null)
            {
                Task.Factory.StartNew(() => myevent())
                    .ContinueWith(t =>
                    {
                        //TODO code to run in UI thread after event runs goes here
                    }, CancellationToken.None
                    , TaskContinuationOptions.None
                    , TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
