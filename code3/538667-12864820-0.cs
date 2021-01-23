    public class ProxyWrapper<TServiceClientType, TResultType>
        where TServiceClientType : class, ICommunicationObject
    {
        private static string _endPoint;
        public ProxyWrapper(string endPoint = "")
        {
            _endPoint = endPoint;
        }
        public TResultType Wrap(Func<string, TServiceClientType> constructWithEndpoint,
                                        Func<TServiceClientType, TResultType> codeBlock)
        {
            TResultType result = default(TResultType);
            TServiceClientType client = default(TServiceClientType);
            try
            {
                client = constructWithEndpoint(_endPoint);
                result = codeBlock(client);
                client.Close();
            }
            catch (Exception)
            {
                if (client != null)
                {
                    client.Abort();
                }
                throw;
            }
            return result;
        }
    }
