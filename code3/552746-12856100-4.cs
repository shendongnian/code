    public class BaseHandler : IHandler
    {
        void IHandler.Handle(IMessage message)
        {
            dynamic d = message;
            Handle(d);
        }
        
        private void Handle<TMessage>(TMessage m) where TMessage : IMessage
        {
            var handler = this as IHandler<TMessage>;
            if(handler == null)
                HandleUnknownMessage((object)m);
            else
                handler.Handle(m);
        }
        
        protected virtual void HandleUnknownMessage(IMessage unknownMessage)
        {
            // Handle unknown message types here.
        }
    }
