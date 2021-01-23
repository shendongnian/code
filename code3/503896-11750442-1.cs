    /// <summary>
    /// Here was made ILazyInitializer implementation that supports the ISessionImplementor serialization.
    /// </summary>
    [Serializable]
    public class LazyInitializerSrlzSupport : 
        global::Spring.Data.NHibernate.Bytecode.LazyInitializer,
        global::NHibernate.Proxy.ILazyInitializer, 
        AopAlliance.Intercept.IMethodInterceptor
    {
        private static readonly MethodInfo exceptionInternalPreserveStackTrace;
        static LazyInitializerSrlzSupport()
        {
            exceptionInternalPreserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);
        }
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="persistentClass"></param>
        /// <param name="id"></param>
        /// <param name="getIdentifierMethod"></param>
        /// <param name="setIdentifierMethod"></param>
        /// <param name="componentIdType"></param>
        /// <param name="session"></param>
        public LazyInitializerSrlzSupport(
            string entityName, 
            Type persistentClass, 
            object id, 
            MethodInfo getIdentifierMethod, 
            MethodInfo setIdentifierMethod, 
            IAbstractComponentType componentIdType, 
            ISessionImplementor session)
            :base(entityName, 
                persistentClass, 
                id, 
                getIdentifierMethod, 
                setIdentifierMethod, 
                componentIdType, 
                session)
        {
            this._sessionSrlzSupport = session;
        }
        /// <summary>
        /// This must be the trick. This will be serialized so that 
        /// we can load the session in the "dynamic proxy".
        /// </summary>
        private ISessionImplementor _sessionSrlzSupport;
        #region ILazyInitializer Members
        public new void Initialize()
        {
            if (this.Session == null)
            {
                this.Session = this._sessionSrlzSupport;
            }
            base.Initialize();
        }
        public new object GetImplementation()
        {
            this.Initialize();
            return base.Target;
        }
        #endregion
        #region IMethodInterceptor Members
        object IMethodInterceptor.Invoke(IMethodInvocation invocation)
        {
            try
            {
                MethodInfo methodInfo = invocation.Method;
                object returnValue = base.Invoke(methodInfo, invocation.Arguments, invocation.Proxy);
                if (returnValue != InvokeImplementation)
                {
                    return returnValue;
                }
                SafeMethod method = new SafeMethod(methodInfo);
                return method.Invoke(this.GetImplementation(), invocation.Arguments);
            }
            catch (TargetInvocationException ex)
            {
                exceptionInternalPreserveStackTrace.Invoke(ex.InnerException, new Object[] { });
                throw ex.InnerException;
            }
        }
        #endregion
    }
