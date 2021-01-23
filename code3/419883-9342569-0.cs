    class Foo
    {
        public Foo(SynchronizationContext context)
        {
            this.context = context ?? new SynchronizationContext();
            this.someEventHandlers = new Dictionary<EventHandler, EventHandler>();
        }
    
        private readonly SynchronizationContext context;
        // ^ could also use ISynchronizeInvoke; I chose SynchronizationContext
        //   for this example because it is independent from, but compatible with,
        //   Windows Forms.
        public event EventHandler SomeEvent
        {
            add
            {
                EventHandler wrappedHandler = 
                    (object s, EventArgs e) =>
                    {
                        context.Send(delegate { value(s, e); }, null);
                        // ^ here is where you'd call ISynchronizeInvoke.Invoke().
                    };
                someEvent += wrappedHandler;
                someEventHandlers[value] = wrappedHandler;
            }
            remove
            {
                if (someEventHandlers.ContainsKey(value))
                {
                    someEvent -= someEventHandlers[value];
                    someEventHandlers.Remove(value);
                }
            }
        }
        private EventHandler someEvent = delegate {};
        private Dictionary<EventHandler, EventHandler> someEventHandlers;
    
        public void RaiseSomeEvent()
        {
            someEvent(this, EventArgs.Empty);
            // if this is actually the only place where you'd invoke the event,
            // then you'd have far less overhead if you moved the ISynchronize-
            // Invoke.Invoke() here and forgot about all the wrapping above...!
        }
    }
