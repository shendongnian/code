    public abstract class BaseMessageHandler {
    
        public abstract bool CanHandle(BaseMessage msgToHandle)
        public abstract void Handle(BaseMessage msgToHandle);
    
    }
    public class MessageForwarderHandler : BaseMessageHandler {
    
        public bool CanHandle(BaseMessage msgToHandle)
        {
            return msgToHandle is ForwardableMessage;
        }
        public void Handle(BaseMessage msgToHandle)
        {
            // do the forwarding logic here
        }
    
    }
    public class MessageOfTypeAHandler : BaseMessageHandler {
    
        public bool CanHandle(BaseMessage msgToHandle)
        {
            return msgToHandle is MessageOfTypeA;
        }
        public void Handle(BaseMessage msgToHandle)
        {
            // do the logic specific to messages of type A
        }
    
    }
