    public class GenericsTest<T> where T: ISomeInterface
    {
        private List<T> someList = new List<T>();
    
        public IEnumerable<ISomeInterface> GetList()
        {
            return (IEnumerable<ISomeInterface>)someList;
        }
    }
