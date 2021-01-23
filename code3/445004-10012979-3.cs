	public class ClientOld : IServiceOld
    {
        private IServiceOld m_Client;
        public ClientOld()
        {
            var factory = new ChannelFactory<IServiceOld>(new WSHttpBinding(), "http://localhost:8732/test/old");
            m_Client = factory.CreateChannel();
        }
        public void DoWork()
        {
            m_Client.DoWork();
        }
		
		...
    }
