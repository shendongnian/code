    public class SomeClassAdapter
    {
        private readonly SomeClass obj;
    
        public SomeClassAdapter(SomeClass obj)
        {
            this.obj = obj;
            this.obj.SomeEvent += HandleSomeClassSomeEvent;
        }
    
        private void HandleSomeClassSomeEvent(object sender, SomeEventArgs args)
        {
            OnSomeEvent(ConvertEventArgs(args));
        }
    
        private MyEventArgs ConvertEventArgs(SomeEventArgs args)
        {
            // the magic goes here...
        }
    
        protected virtual void OnSomeEvent(MyEventArgs args)
        {
            var handler = SomeEvent;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    
        public event EventHandler<MyEventArgs> SomeEvent;
    }
