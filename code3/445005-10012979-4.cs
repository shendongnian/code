	public class ClientNew : IServiceOld
    {
        private IServiceNew m_Client;
        public ClientNew()
        {
            var factory = new ChannelFactory<IServiceNew>(new WSHttpBinding(), "http://localhost:8732/test/new");
            m_Client = factory.CreateChannel();
        }
        public void DoWork()
        {
            m_Client.DoWork();
            m_Client.DoAdditionalWork();
        }
		...
    }
