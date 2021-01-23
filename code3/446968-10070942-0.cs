    public class CachingProxy<T> : ProxyBase<T> where T : class {
        private readonly IDictionary<Int32, Object> _cache = new Dictionary<Int32, Object>();
        public CachingProxy(T instance)
            : base(instance) {
        }
        protected override IMethodReturnMessage InvokeMethodCall(IMethodCallMessage msg) {
            var cacheKey = GetMethodCallHashCode(msg);
            Object result;
            if (_cache.TryGetValue(cacheKey, out result))
                return new ReturnMessage(result, msg.Args, msg.ArgCount, msg.LogicalCallContext, msg);
            var returnMessage = base.InvokeMethodCall(msg);
            if (returnMessage.Exception == null)
                _cache[cacheKey] = returnMessage.ReturnValue;
            return returnMessage;
        }
        protected virtual Int32 GetMethodCallHashCode(IMethodCallMessage msg) {
            var hash = msg.MethodBase.GetHashCode();
            foreach(var arg in msg.InArgs) {
                var argHash = (arg != null) ? arg.GetHashCode() : 0;
                hash = ((hash << 5) + hash) ^ argHash;
            }
            return hash;
        }
    }
