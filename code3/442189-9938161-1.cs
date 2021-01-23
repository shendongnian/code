    public class Tor<T> where T : new()
    {
        public Tor(int size)
        { 
            elements = Enumerable.Range(1,size).Select (e => new T()).ToArray(); 
        }
        ...
    }
