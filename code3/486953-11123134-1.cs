    public class Client : IProcessorCallBack
    {
        DuplexChannelFactory<IProcessor> _processorFactory;
        IProcessor _processor
        void OpenProcessor()
        {
            _speechMikeProcessorFactory = new DuplexChannelFactory<IProcessor>(
                  this,
                  new NetNamedPipeBinding(),
                  new EndpointAddress(baseUri + @"/" + HostName));
            _processor = _speechMikeProcessorFactory.CreateChannel();
            _processor.SubscribeToEvents();
        }
        void OnEvent(EventArgs args)
        {
             //Do Stuff
        }
    }
