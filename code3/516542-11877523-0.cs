    public class MyConnectionFactory : IConnectionIdGenerator
    {
        public string GenerateConnectionId(IRequest request)
        {
            return "some generated ID";
        }
    }
