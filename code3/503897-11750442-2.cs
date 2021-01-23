    /// <summary>
    /// TODO:
    /// </summary>
    public class BytecodeProviderSrlzSupport : 
        global::Spring.Data.NHibernate.Bytecode.BytecodeProvider,
        global::NHibernate.Bytecode.IBytecodeProvider
    {
        private IProxyFactoryFactory proxyFactoryFactory;
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="listableObjectFactory"></param>
        public BytecodeProviderSrlzSupport(IListableObjectFactory listableObjectFactory)
            : base(listableObjectFactory)
        {
            this.proxyFactoryFactory = new ProxyFactoryFactorySrlzSupport();
        }
        #region IBytecodeProvider Members
        IProxyFactoryFactory IBytecodeProvider.ProxyFactoryFactory
        {
            get { return this.proxyFactoryFactory; }
        }
        #endregion
    }
