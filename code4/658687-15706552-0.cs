    public class YourClass<T> where T : Ihavelocation, ihavecolor{
        List<T> items = new List<T>;
    
        public void Add(T item){
            items.Add(item);
        }
    
    }
