    public static class MessageHandlersProvider
    {
        IEnumerable<MessageHandler> handlers = new List<MessageHandler>()
        {
            new MessageOfTypeAHandler(),
            new MessageForwarderHandler()
        }
        public static void HandleMessage(BaseMessage msg)
        {
            foreach (MessageHandler handler in handlers)
            {
                if (handler.CanHandle(msg))
                {
                    handler.Handle(msg);
                    // you may stop once you have found a handler that can handle or you might consider that multiple handlers can be applied to the same message
                }
            }
        }
    }
