    public sealed class AuditAttribute : HandlerAttribute, ICallHandler
    {
        #region attribute properties
        public string Key { get; set; } // your own attribute properties
        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {
            return this;
        }
        #endregion
        #region ICallHandler
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            // do stuff ...
            // then
            return getNext()(input, getNext);
        }
        public int Order { get; set; }
        #endregion
    }
