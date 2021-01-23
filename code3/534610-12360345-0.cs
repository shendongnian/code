    public class MyProvider
    {
        private readonly Func<IPopClient> popClientFactory;
    
        public MyProvider(Func<IPopClient> popClientFactory)
        {
            this.popClientFactory = popClientFactory;
        }
    
        public void Fetch()
        {
            using (var pop3 = popClientFactory())
            {
                ....
            }
        }
    }
