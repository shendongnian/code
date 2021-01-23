    public class MyCollection<T> : IEnumerable<T>
    {
        public void Add(T item, int number)
        {
  
        }
        public void Add(T item, string text) 
        {
   
        }
        public bool Add(T item) //return type could be anything
        {
    
        }
    }
    var myCollection = new MyCollection<bool> 
    {
        true,
        { false, 0 },
        { true, "" },
        false
    };
