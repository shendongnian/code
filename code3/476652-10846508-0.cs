    public class LogList<T> : List<T>
        {
            public LogList()
                : base()
            {
                Debug.WriteLine("LogList- Construction");
            }
    
            public new void Add(T item)
            {
                Debug.WriteLine("LogList - Add");
                base.Add(item);
            }
    
            public new void Remove(T item)
            {
                Debug.WriteLine("LogList - Remove");
                base.Remove(item);
            }
    
            public new void RemoveAt(int index)
            {
                Debug.WriteLine("LogLost - RemoveAt");
                base.RemoveAt(index);
            }
    
            public new void Clear()
            {
                Debug.WriteLine("LogList - Clear");
                base.Clear();
            }
        }
