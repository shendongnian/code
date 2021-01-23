    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : OutputCacheAttribute
    {
        public NoCacheAttribute()
        {
            this.Duration = 0;
        }
    }
