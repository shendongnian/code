    public class SvcHelper
    {
        public static void Using<TClient>(Action<TClient> action) where TClient : ICommunicationObject, IDisposable
        {
            ChannelFactory<TClient> cnFactory = new ChannelFactory<TClient>("SomethingWebService");
            TClient client = cnFactory.CreateChannel();
            using (new OperationContextScope((IContextChannel)client))
            {
                action(client);
            }
        }
    }
