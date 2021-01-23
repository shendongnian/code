    public class MessageHandlerAdapter<TMessage>
       : IHandleMessages<TMessage>
    {
        public void Handle(TMessage message)
        {
            new MyCustomHandler().HandleMessageMyWay(message);
        }
    }
