    public interface IWidgetRepository
    {
       IQueryable<Widget> Retrieve();
    } 
    
    public class WidgetController
    {
       public IWidgetRepository WidgetRepository {get; set;}
    
    
       public IQueryable<Widget> Get()
       {
          return WidgetRepository.Get();
       }
    }
