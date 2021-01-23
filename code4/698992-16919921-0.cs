        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public sealed class DoCheckAttribute : InterceptAttribute
        {
            public override IInterceptor CreateInterceptor(IProxyRequest request)
            {
                return request.Context.Kernel.Get<RequiresDatabaseInterceptor>();
            }
        }
