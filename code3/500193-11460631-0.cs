    public class MyClass
    {
        public MyClass()
        {
            this.Event += (sender, e) => ();
        }
    
        public event EventHandler Event;
    
        protected virtual void OnEvent()
        {
            this.Event(this, EventArgs.Empty);
        }
    }
