    /// <summary>
    /// TODO:
    /// </summary>
    public class ProxyFactoryFactorySrlzSupport : 
        global::NHibernate.Bytecode.IProxyFactoryFactory
    {
        #region IProxyFactoryFactory Members
        /// <summary>
        /// Build a proxy factory specifically for handling runtime lazy loading. 
        /// </summary>
        /// <returns>The lazy-load proxy factory.</returns>
        public IProxyFactory BuildProxyFactory()
        {
            return new ProxyFactorySrlzSupport();
        }
        ///<summary>
        ///</summary>
        public IProxyValidator ProxyValidator
        {
            get { return new DynProxyTypeValidator(); }
        }
        #endregion
    }
