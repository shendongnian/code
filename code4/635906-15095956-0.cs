    public class Foo
    {
        public event EventHandler SomeEvent;
        public void Trigger()
        {
            if(SomeEvent != null)
            {
                SomeEvent(this, new EventArgs());
            }
        }
    }
