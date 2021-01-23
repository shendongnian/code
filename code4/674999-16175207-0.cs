    public abstract class BaseMessage { ... } // base class inherited by every message
    public abstract class ForwardableMessage : BaseMessage { ... } // base class for message that should only be forwarded
    public class MessageOfTypeA : BaseMessage { ... } // a message of type A (which is not forwardable)
    public class MessageOfTypeB : ForwardableMessage { ... } // a message of type B (which is forwardable)
    public class MessageOfTypeC : ForwardableMessage { ... } // a message of type C (which is forwardable)
