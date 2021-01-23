    public class ConnectionFactory : IConnectionIdGenerator
    {
        public string GenerateConnectionId(IRequest request)
        {
            if (request.Cookies["UserGuid"] != null)
                return request.Cookies["UserGuid"].Value;
    
            throw new ApplicationException("No User Id cookie was found on this browser; you must have cookies enabled to enter.");
        }
    }
