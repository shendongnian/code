    public class RabbitMQUserClass
    {
        public ConnectionFactory ConnectionFactory {get; private set;}
        public RabbitMQUserClass(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory.Get();
        }
    }
