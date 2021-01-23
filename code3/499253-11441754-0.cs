    class Host
    {
        private Subject<IMessage> _outbound;
    
        public Host(IObservable<IMessage> messages)
        {
            _outbound = new Subject<IMessage>();        
            messages.SubscribeOn(Scheduler.TaskPool).Subscribe(ProcessIncomingMessage);
        }
        
        private void ProcessIncomingMessage(IMessage message)
        {
            _outbound.OnNext(message); // just echo
        }
        
        public IObservable<IMessage> Messages { get { return _outbound.AsObservable(); } }
    }
    
    class Client
    {
        public Client(IObservable<IMessage> messages)
        {
            messages.SubscribeOn(Scheduler.TaskPool).Subscribe(ProcessIncomingMessage);
        }
        
        private void ProcessIncomingMessage(IMessage message)
        {
            // interpret the message and update state
        }
    }
