    public class Foo
    {
        public event Action MyEvent;
        public void FireEvent()
        {
            Action myevent = MyEvent;
            if (MyEvent != null)
            {
                Task.Factory.StartNew(() => myevent());
                //TODO code to run in UI thread while event handlers run goes here
            }
        }
    }
