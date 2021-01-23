    public abstract class RavenDbFactBase : IDisposable
    {        
        public class NoStaleQueriesListener : IDocumentQueryListener
        {
            public void BeforeQueryExecuted(IDocumentQueryCustomization c)
            {
                c.WaitForNonStaleResults();
            }        
        }        
    }
