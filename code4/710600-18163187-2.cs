    public class SessionBasedSiteMapCacheKeyGenerator
        : ISiteMapCacheKeyGenerator
    {
        public UserBasedSiteMapCacheKeyGenerator(
            IMvcContextFactory mvcContextFactory
            )
        {
            if (mvcContextFactory == null)
                throw new ArgumentNullException("mvcContextFactory");
            this.mvcContextFactory = mvcContextFactory;
        }
        protected readonly IMvcContextFactory mvcContextFactory;
        #region ISiteMapCacheKeyGenerator Members
        public virtual string GenerateKey()
        {
            var context = mvcContextFactory.CreateHttpContext();
            var builder = new StringBuilder();
            builder.Append("sitemap://");
            builder.Append(context.Request.Url.DnsSafeHost);
            builder.Append("/?sessionId=");
            builder.Append(context.Session.SessionID);
            return builder.ToString();
        }
        #endregion
    }
