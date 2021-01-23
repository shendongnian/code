        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class NoCacheAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                var filter=filterContext.Filters.Where(t => t.GetType() == typeof(ResponseCacheFilter)).FirstOrDefault();
                if (filter != null)
                {
                    ResponseCacheFilter f = (ResponseCacheFilter)filter;
                    f.NoStore = true;
                    //f.Duration = 0;
                }
            
                base.OnResultExecuting(filterContext);
            }
        }
