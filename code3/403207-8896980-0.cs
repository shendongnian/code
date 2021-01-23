    public class MyService
    {
        public void GetModels(Action<MyViewModel, object> onModelAvailable, object state, Action onComplete)
        {
            Task.Factory.StartNew(x =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        onModelAvailable(new MyViewModel
                        {
                            Foo = "foo " + i
                        }, x);
                        Thread.Sleep(1000);
                    }
                }
                finally
                {
                    onComplete();
                }
            }, state);
        }
    }
