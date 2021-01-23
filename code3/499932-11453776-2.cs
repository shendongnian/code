    public class JavaScript : WebResourceBase
    {
        public JavaScript()
        {
        }
        private JavaScript(string s)
        {
        }
        static JavaScript()
        {
            Subscribe("js", s => (ResourceBase)new JavaScript(s));
        }
    }
