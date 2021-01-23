    public interface IMessage
    {
        string MessageType { get; }
    }
    public interface IMessageHandler
    {
        string GetMessageType();
    }
    public class RegisterUserMessage : IMessage
    {
        public string MessageType
        {
            get { return "RegisterUser"; }
        }
    }
    public class RegisterUserMessageHandler : IMessageHandler
    {
        public string GetMessageType()
        {
            return "RegisterUser";
        }
    }
    public class RemoveUserMessage : IMessage
    {
        public string MessageType
        {
            get { return "RemoveUser"; }
        }
    }
    public class RemoveUserMessageHandler : IMessageHandler
    {
        public string GetMessageType()
        {
            return "RemoveUser";
        }
    }    
