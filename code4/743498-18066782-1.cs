    public class Flattener<T> : IEnumerable<T>
    {
        private List<T> _collection = new List<T> ( );
        public void Add ( params T [ ] list )
        {
            _collection.AddRange ( list );
        }
        public void Add ( params IEnumerable<T> [ ] lists )
        {
            foreach ( var list in lists )
                _collection.AddRange ( list );
        }
        public T Result
        {
            get
            {
                return _collection.ToArray();
            }
        }
        public IEnumerator<T> GetEnumerator ( )
        {
            return _collection.GetEnumerator ( );
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ( )
        {
            return GetEnumerator ( );
        }
    }
    Flattener<Foo> foos = new Flattener();
    foos.Add(fooList, fooList2, fooList3,...);
    foos.Add(foo1,foo2,foo3,...);
    DoStuff(foos.Result);
    
