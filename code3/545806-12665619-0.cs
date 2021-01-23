    public class MyEventRaiser
    {
        public event EventHandler<string> MyEvent = delegate { };
        public void Process(string data)
        {
            // do something interestuing
            Thread.Sleep(2000);
            if (!string.IsNullOrEmpty(data))
            {
                this.MyEvent(this, data + " at: " + DateTime.Now.ToString());
            }
        }
    }
