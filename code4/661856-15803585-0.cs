    class MyClass
    {
        private EventHandler myEvent;
        private void OnEventHandlerRegistered()
        {
            Console.WriteLine("Event handler registered.");
        }
        public event EventHandler MyEvent
        {
            add 
            {
                myEvent += value;
                OnEventHandlerRegistered();
            }
            remove
            {
                myEvent -= value;
            }
        }
    }
