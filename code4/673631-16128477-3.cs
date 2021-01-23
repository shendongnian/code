    public abstract class ForestBase
    {
        private static List<object> _staticList = new List<object>();
    
        protected List<object> StaticList
        {
            get { return _staticList; }
        }
    }
    
    public class Forest<T1, T2> : ForestBase
    {
        public void Foo()
        {
            StaticList.Add( 12345 );
        }
    }
