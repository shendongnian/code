    abstract class CommsMessage 
    { 
        public abstract void Visit(CommsMessageVisitor v);
    }
    class Message1 : CommsMessage 
    {
        public void Visit(CommsMessageVisitor v) { v.Accept(this); }
    }
    class Message2 : CommsMessage 
    {
        public void Visit(CommsMessageVisitor v) { v.Accept(this); }
    }
    interface CommsMessageVisitor 
    {
       void Accept(Message1 msg1);
       void Accept(Message1 msg2);
    }
