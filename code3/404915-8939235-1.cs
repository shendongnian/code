    public class CommsMessage
    {
        public virtual void ProcessMessage()
        {
           // Common stuff.
        }
    }
    public class MessageType1 : CommsMessage
    {
       public override void ProcessMessage()
       {
          base.ProcessMessage();
          // type 1 specific stuff.
       }
    }
    // ...
    
    void ProcessIncomingMessage(CommsMessage msg)
    {
       msg.ProcessMessage();
    }
