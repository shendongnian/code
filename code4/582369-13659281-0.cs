    // Your message classes
    public class MyClass : IMessage
    {
        // Implement acceptance of handler:
        public void AcceptHandler(IMessageHandler handler)
        {
            handler.HandleMessage(this);
        }
    }
    
    public class MyClass2 : MyClass
    {
         // Nothing more here
    }
    // Define interface of message
    public interface IMessage
    {
        void AcceptHandler(IMessageHandler handler)
    }
    // Define interface of handler
    public interface IMessageHandler
    {
        // For each type of message, define separate method
        void HandleMessage(MyClass message)
        void HandleMessage(MyClass2 message)
    }
    // Implemente actual handler implementation
    public class MessageHandler : IMessageHandler 
    {
        // Main handler method
        public void HandleSomeMessage(MyClass message) // Or it could be IMessage
        {
             // Pass this handler to message. Since message implements AcceptHandler
             // as just passing itself to handler, correct method of handler for MyClass
             // or MyClass2 will be called at runtime.
             message.AcceptHandler(this);
        }
        public void HandleMessage(MyClass message)
        {
             // Implement what do you need to be done for MyClass
        }
        public void HandleMessage(MyClass2 message)
        {
             // Implement what do you need to be done for MyClass2
             // If code of MyClass should be run too, just call 
             // this.HandleMessage((MyClass)message);
        }
    }
