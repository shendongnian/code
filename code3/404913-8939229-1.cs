    void ProcessIncomingMessage(CommsMessage msg) 
    {
      new MyVisitor().Visit(msg);
    }
    class MyVisitor : CommsMessageVisitor
    {
        void Accept(Message1 msg1) { ProcessMessageType1(msg1); }
        void Accept(Message1 msg2) { ProcessMessageType2(msg2); }
    }
