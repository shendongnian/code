    IEnumerable<T> GetAllByFiilter(FilterModel filter);
    public class FilterModel {
       public string Lastname {get;set;}
       public string Firstname {get;set;}
    }
    public IEnumerable<T> GetAllByFilter(FilterModel filter) {
       if(!string.IsNullOrWhiteSpace(filter.Lastname) { 
         //add restriction
       }
       // .. etc ..
    }
    
