    public interface IProtocolFactory
    {
        ProtocolBaseClass Create();
    }
    public class SomeDerivedProtocolFactory : IProtocolFactory
    {
        public ProtocolBaseClass Create()
        {
            return new SomeDerivedProtocol();
        }
    }
