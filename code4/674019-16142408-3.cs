    public class Base {
          
        List<Animals> animals = .... 
        ...
        ....
    
        public IEnumerable<T> GetChildrenOfType<T>()  
            where T : Animals
        {
           return animals.OfType<T>();  // using System.Linq;
        }
    }
