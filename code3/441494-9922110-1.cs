    interface ISession
    {
        void Connect();
        // session members
    }
    class FakeSession : ISession
    {
        public void Connect() { }
        public void Query()
        {
            Console.WriteLine("fake implementation");
        }
    }
    static class ISessionExtensions
    {
        public static void Query(this ISession test)
        {
            Console.WriteLine("real implementation");
        }
    }
    class SessionProxy<TInnerSession> : ISession where TInnerSession: ISession
    {
        private TInnerSession innerSession;
        public SessionProxy(TInnerSession session)
	    {
            innerSession = session;
	    }
        public void Connect()
        { 
            innerSession.Connect();
        }
        public void Query()
        {
            innerSession.Query();
        }
    }
        static void Main(String[] args)
        {
            FakeSession fakeSession =new FakeSession();
            ISession sessionProxy = new SessionProxy<FakeSession>(fakeSession);
            Stub(sessionProxy);
        }
        static void Stub(ISession session)
        {
            session.Query();
        }
