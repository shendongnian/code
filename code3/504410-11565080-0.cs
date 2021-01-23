    public class FakeESBSingleMessage<T> : IBusEnabledClass
    {
        private Action<T> SubscribedAction { get; set; }
    
        #region IBusEnabledClass
    
        public void Publish(T message)
        {
            SubscribedAction(message);
        }
    
        public void Subscribe(string ID, Action<T> action)
        {
            SubscribedAction = action;
        }
    
        #endregion
    }
