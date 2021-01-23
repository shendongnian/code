    public class LongTask
        {
            public event EventHandler MyEvent;
    
            public void Execute()
            {
                var task = Task.Factory.StartNew(() =>
                {
                   
                    while (true)
                    {
                        // condition met to notify UI
                        if (MyEvent != null)
                            MyEvent(this, null);
                    }
                });
            }
        }
