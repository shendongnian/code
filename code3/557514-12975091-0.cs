    public class Container
    {
        public interface INested
        {
            /* members here */
        }
        private class Nested : INested
        {
            public Nested() { }
        }
    
        public INested CreateNested()
        {
            return new Nested();  // Allow
        }
    }
    class External
    {
        static void Main(string[] args)
        {
            Container containerObj = new Container();
            Container.INested nestedObj;
    
            nestedObj = new Container.Nested();       // Prevent
            nestedObj = containerObj.CreateNested();  // Allow
    
        }
    }
