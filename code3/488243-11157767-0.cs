    class Ranch<T>: IEnumerable<T> // <-- click here in VS
    {
        List<T> _madCode = new List<T>(); // Mad code
    
        IEnumerator<T> GetEnumerator()
        {
            return _madCode.GetEnumerator(); // Hectic implementation details
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }
    
       // More mad code
    }
