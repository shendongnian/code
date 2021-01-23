    /// <summary>
    /// TODO:
    /// </summary>
    public class ProxyFactorySrlzSupport : 
        global::Spring.Data.NHibernate.Bytecode.ProxyFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProxyFactorySrlzSupport));
        [Serializable]
        private class SerializableProxyFactory : global::Spring.Aop.Framework.ProxyFactory
        {
            // ensure proxy types are generated as Serializable
            public override bool IsSerializable
            {
                get { return true; }
            }
        }
        public override global::NHibernate.Proxy.INHibernateProxy GetProxy(object id, global::NHibernate.Engine.ISessionImplementor session)
        {
            try
            {
                // PersistentClass = PersistentClass.IsInterface ? typeof(object) : PersistentClass
                LazyInitializer initializer = new LazyInitializerSrlzSupport(EntityName, PersistentClass,
                                                      id, GetIdentifierMethod, SetIdentifierMethod, ComponentIdType, session);
                SerializableProxyFactory proxyFactory = new SerializableProxyFactory();
                proxyFactory.Interfaces = Interfaces;
                proxyFactory.TargetSource = initializer;
                proxyFactory.ProxyTargetType = IsClassProxy;
                proxyFactory.AddAdvice(initializer);
                object proxyInstance = proxyFactory.GetProxy();
                return (INHibernateProxy)proxyInstance;
            }
            catch (Exception ex)
            {
                log.Error("Creating a proxy instance failed", ex);
                throw new HibernateException("Creating a proxy instance failed", ex);
            }
        }
    }
