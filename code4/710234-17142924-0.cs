    public Class A 
    {
        private A(string hostname, string port, string username, string pw_hash) {
            //create a new instance with the specified parameters
        }
        //other methods on the connection
        protected void close() {
            //close the connection
        }
        public class AFactory 
        {
        private IList<A> connections = new List<A>();
        private AFactory()
        {
            //do something
        }
        private static readonly Lazy<AFactory> lazy
            = new Lazy<AFactory>(() => new AFactory());
    
        public static AFactory Instance { get { return lazy.Value; } }
    
        public A getA(string hostname, string service, string username, string pw_hash)
        {
            foreach (A a in connections)
            {
                if (a.hostname == hostname && a.service == service && a.username == username)
                    return a;
            }
            A d = new A(hostname, service, username, pw_hash);
            connections.Add(d);
            return d;
        }
        }
    }
    
