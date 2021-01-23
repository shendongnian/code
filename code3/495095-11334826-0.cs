    class ClassWithEvent
    {
        public event EventHandler SomeEvent;
        public Delegate[] GetSomeEventInvocationList()
        {
            return SomeEvent.GetInvocationList();
        }
    }
