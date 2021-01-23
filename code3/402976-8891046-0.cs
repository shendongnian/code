    public class Foo
    {
        private readonly Func<string, List<string>> method;
        
        public Foo()
        {
            this.method = this.FindNearByCity;
        }
        
        public IAsyncResult BeginFindNearByCity(string targetCity, AsyncCallback callback, object obj)
        {
            return this.method.BeginInvoke(targetCity, callback, obj);
        }
        
        public List<string> EndFindNearByCity(IAsyncResult  result)
        {
            return this.method.EndInvoke(result);
        }
        
        public List<string> FindNearByCity(string targetCity)
        {
            // ... some implementation
        }
    }
