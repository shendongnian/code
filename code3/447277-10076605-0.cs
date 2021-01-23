    public class MyList<T> : IList<T>
	{
	    private List<T> _myList = new List<T>();
            public IEnumerator<T> GetEnumerator() { return _myList.GetEnumerator(); }
            public void Clear() { _myList.Clear(); }
            public bool Contains(T item) { return _myList.Contains(item); }
            public void Add(T item) 
            { 
                _myList.Add(item);
                // Call your methods here
            }
             // ...implement the rest of the IList<T> interface using _myList
       }
