    public class Foo : IEnumerable, IEnumerable<HTTPHeaderItem>
    {
    
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        IEnumerator<HTTPHeaderItem> IEnumerable<HTTPHeaderItem>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
