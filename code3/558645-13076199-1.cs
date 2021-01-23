        public ClientRepository(ISession session) 
        {
            if (session == null) throw new ArgumentNullException("nhSession");
            this._session = session;
            CurrentSessionContext.Bind(_session);
        }
