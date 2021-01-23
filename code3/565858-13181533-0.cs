    public interface IConnectionFactory
    {
        ConnectionFactory Get();
        ConnectionFactory Get(string uri);
    }
    public class ConnectionFactoryCreator : IConnectionFactory
    {
        public ConnectionFactory Get(
            string uri = "amqp://user:pass@hostName:port/vhost")
        {
            return new ConnectionFactory
            {
                Uri = uri
            };
        }
    }
