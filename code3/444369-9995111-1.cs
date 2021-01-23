    public class ProviderWrapper : IProvider, IPreProcessor, IHandler
    {
        private IProvider _provider;
        private IPreProcessor _preProcessor;
        private IHandler _handler;
        public ProviderWrapper(IProvider provider, IPreProcessor preProcessor, IHandler handler)
        {
            _provider = provider;
            _preProcessor = preProcessor;
            _handler = handler;
        }
        #region IProvider Members
        public string ProvideSomething(int id)
        {
            return _provider.ProvideSomething(id);
        }
        #endregion
        #region IPreProcessor Members
        public void PreProcess(string parameter)
        {
            _preProcessor.PreProcess(parameter);
        }
        #endregion
        #region IHandler Members
        public void HandleSomething()
        {
            _handler.HandleSomething();
        }
        #endregion
    }
