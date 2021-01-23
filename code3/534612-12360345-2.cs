    public class MyProvider
    {
        private readonly Func<IPopClient> createPopClient;
    
        public MyProvider(Func<IPopClient> popClientFactory)
        {
            this.createPopClient = popClientFactory;
        }
    
        public void Fetch()
        {
            using (var pop3 = createPopClient())
            {
                ....
            }
        }
    }
