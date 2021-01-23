    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(IProcessorCallBack))]
    public interface IProcessor
    {
        [OperationContract]
        Boolean SubscribeToEvents();
        [OperationContract]
        Boolean UnsubscribeToEvents();
    }
    public interface IProcessorCallBack
    {
        [OperationContract(IsOneWay = true)]
        void OnEvent(EventArgs args);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DDSpeechMikeProcessor:IProcessor
    {
        private readonly List<IProcessorCallBack> _eventListeners = 
            new List<IProcessorCallBack>();
        public bool SubscribeToEvents()
        {
            var listenerToCallBacks =    
                OperationContext.Current.GetCallbackChannel<IProcessorCallBack>();
            if(!_eventListeners.Contains(listenerToCallBacks))
                _eventListeners.Add(listenerToCallBacks);
        }
     
        public bool UnsubscribeToEvents()
        {
            var listenerToCallBacks = 
                OperationContext.Current.GetCallbackChannel<IProcessorCallBack>();
            if (_eventListeners.Contains(listenerToCallBacks))
                _eventListeners.Remove(listenerToCallBacks);
        }
        //This is your server listening for the main event
        //which it will pass on to all listeners
        void OnEvent(EventArgs args)
        {
            foreach(var listener in _eventListeners)
            {
                try
                {
                    listener.OnEvent(args);
                }
                catch (Exception exception)
                {
                    RemoveListenerIfBadCommunication(listener, exception);
                }
            }
        }
 
        //If a listener did not unsubscribe before shutting down you will get exceptions
        private void RemoveListenerIfBadCommunication(IProcessorCallBack listener, 
            Exception exception)
        {
            if (exception.GetType() == typeof(CommunicationException)
                || exception.GetType() == typeof(CommunicationObjectAbortedException)
                || exception.GetType() == typeof(CommunicationObjectFaultedException)
            )
               _eventListeners.Remove(listener);
        }
    }
