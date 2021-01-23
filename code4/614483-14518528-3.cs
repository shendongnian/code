    public class ClassA : IEventHandler<UserCreated>
    {
        IEventManager _eventManager
    
        public ClassA(IEventManager manager)
        {
           // I subscribe on this event (which is published by the other class)
           manager.Subscribe<UserCreated>(this);
           _eventManager = manager;
        } 
    
        public void Handle(UserCreated theEvent)
        {
            //gets invoked when the event is published by the other class
        }
    
        private void SomeInternalMethod()
        {
            //some business logic
            //and I publish this event
            _eventManager.Publish(new EmailSent(someFields));
        }
    }
