    public class Base {
          
        List<Animals> animals = .... 
        ...
        ....
    
        public IEnumerable<T> GetChildrenOfType<T>()  {
           return animals.OfType(T);
        }
    }
