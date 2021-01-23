    public interface IMySearchSpec 
    {
       string City { get; }
       string State { get; }
    }
    
    public class MyViewModel : IMySearchSpec
    {
       ...implement IMySearchSpec and perhaps other things...
    }
    
    public static class QueryExtensions
    {
       public static IQueryable<T> ApplyPredicate(this IQueryable<T> query, IMySearchSpec searchSpec) 
       {
            if (searchSpec.City != null )
            {
                query = query.Where( x => x.City == searchSpec.city );
            }
            // ..etc..
           return query;
       }
    }
    // then, in your controller
    var filteredQuery = query.ApplyPredicate(viewModel);
