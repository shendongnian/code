    public class Foo
    {
        public event EventHandler MyEvent;
        protected virtual void OnMyEvent(EventArgs e)
        {
            EventHandler handler = MyEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
