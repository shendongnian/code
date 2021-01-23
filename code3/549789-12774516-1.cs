        private ICacheClient cache;
        public virtual ICacheClient Cache
        {
            get { return cache ?? (cache = TryResolve<ICacheClient>()); }
        }
        private ISessionFactory sessionFactory;
        public virtual ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = TryResolve<ISessionFactory>()) ?? new SessionFactory(Cache); }
        }
        /// <summary>
        /// Dynamic Session Bag
        /// </summary>
        private ISession session;
        public virtual ISession Session
        {
            get
            {
                return session ?? (session = SessionFactory.GetOrCreateSession(Request, Response));
            }
        }
        /// <summary>
        /// Typed UserSession
        /// </summary>
        private object userSession;
        protected virtual TUserSession SessionAs<TUserSession>()
        {
            return (TUserSession)(userSession ?? (userSession = Cache.SessionAs<TUserSession>(Request, Response)));
        }
