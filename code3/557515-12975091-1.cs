    public class Container
    {
        public abstract class Nested { }
        private class NestedImpl : Nested { }
        public Nested CreateNested()
        {
            return new NestedImpl();  // Allow
        }
    }
    
    class External
    {
        static void Main(string[] args)
        {
            Container containerObj = new Container();
            Container.Nested nestedObj;
    
            nestedObj = new Container.Nested();       // Prevent
            nestedObj = containerObj.CreateNested();  // Allow
    
        }
    }
