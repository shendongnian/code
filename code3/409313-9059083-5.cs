    var store = new EmbeddableDocumentStore { RunInMemory = true };
    store.Initialize();
    store.RegisterListener(new ForceNonStaleQueryListener());
    public class ForceNonStaleQueryListener : IDocumentQueryListener
    {
        public void BeforeQueryExecuted(IDocumentQueryCustomization customization)
        {
            queryCustomization.WaitForNonStaleResults();
        }
    }
