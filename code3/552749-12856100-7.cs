    public class BaseHandler : IHandler
    {
        void IHandler.Handle(IMessage message)
        {
            dynamic d = message;
            Handle(d);
        }
        
        private void Handle<TMessage>(TMessage message) where TMessage : IMessage
        {
            var handler = this as IHandler<TMessage>;
            if(handler == null)
                HandleUnknownMessage(message);
            else
                handler.Handle(message);
        }
        
        protected virtual void HandleUnknownMessage(IMessage unknownMessage)
        {
            // Handle unknown message types here.
        }
    }
