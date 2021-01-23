    public class SpecialList <T> : ICollection<T>
    { 
        private List <T> mylist;
    
        public SpecialList() 
        { 
            mylist = new List <T>();
        }
        // ICollection<T>.Add
        public void Add(T item)
        {
            // delegate to myList
            myList.Add(item);
        }
        ... /Clear/Contains/CopyTo/ etc
    }
