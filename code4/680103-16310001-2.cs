    public class MyContext : DbContext
    {
        public MyContext()
        {
            var objectContextAdapter = this as IObjectContextAdapter;
            objectContextAdapter.
                ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;    
        }
    }
       
