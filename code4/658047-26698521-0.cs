    namespace DoubleDispatch
    {
    public interface IMessage
    {
        void Dispatch(HandlerBase handler);
    }
    public interface IHandler
    {
        void HandleDefault(IMessage message);
    }
    public interface IHandler<in TMessage> : IHandler
        where TMessage : class, IMessage
    {
        void HandleSpecific(TMessage message);
    }
    public interface IMessage<TMessage, THandler> : IMessage
        where TMessage : class, IMessage<TMessage, THandler>
        where THandler : class, IHandler<TMessage>
    {
    }
    public abstract class HandlerBase : IHandler
    {
        public void HandleDefault(IMessage message)
        {
            Console.WriteLine("HandlerBase process {0}", message.GetType().Name);
        }
    }
    public abstract class MessageBase<TMessage, THandler>
        : IMessage<TMessage, IHandler<TMessage>>
        where TMessage : class, IMessage, IMessage<TMessage, IHandler<TMessage>>
        where THandler : class, IHandler, IHandler<TMessage>
    {
        public void Dispatch(HandlerBase handler)
        {
            var runtimeHandler = handler as THandler;
            if (runtimeHandler != null)
            {
                var runtimeMessage = this as TMessage;
                if (runtimeMessage != null)
                {
                    runtimeHandler.HandleSpecific(runtimeMessage);
                    return;
                }
            }
            handler.HandleDefault(this);
        }
    }
    public class FirstMessage : MessageBase<FirstMessage, IHandler<FirstMessage>>
    {
    }
    public class SecondMessage : MessageBase<SecondMessage, IHandler<SecondMessage>>
    {
    }
    public class FirstHandler : HandlerBase, IHandler<FirstMessage>
    {
        public void HandleSpecific(FirstMessage message)
        {
            Console.WriteLine("FirstHandler process {0}", message.GetType().Name);
        }
    }
    public class SecondHandler : HandlerBase, IHandler<SecondMessage>
    {
        public void HandleSpecific(SecondMessage message)
        {
            Console.WriteLine("SecondHandler process {0}", message.GetType().Name);
        }
    }
    public class ThirdHandler : HandlerBase, IHandler<FirstMessage>, IHandler<SecondMessage>
    {
        public void HandleSpecific(FirstMessage message)
        {
            Console.WriteLine("ThirdHandler process {0}", message.GetType().Name);
        }
        public void HandleSpecific(SecondMessage message)
        {
            Console.WriteLine("ThirdHandler process {0}", message.GetType().Name);
        }
    }
    public class EmptyHandler : HandlerBase
    {
    }
    public static class DoubleDispatch
    {
        public static void Test()
        {
            var handlers = new HandlerBase[]
            {
                new FirstHandler(),
                new SecondHandler(),
                new ThirdHandler(), 
                new EmptyHandler(), 
            };
            var messages = new IMessage[]
            {
                new FirstMessage(),
                new SecondMessage(), 
            };
            Array.ForEach(messages, m =>
            {
                Array.ForEach(handlers, m.Dispatch);
                Console.WriteLine();
            });
        }
    }
    }
