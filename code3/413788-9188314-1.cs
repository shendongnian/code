    // Initialise the Store.
    var documentStore = new EmbeddableDocumentStore
                        {
                            RunInMemory = true
                        };
    documentStore.Initialize();
    
    // Force query's to wait for index's to catch up. Unit Testing only :P
    documentStore.RegisterListener(new NoStaleQueriesListener());
    
    ....
    
    
    #region Nested type: NoStaleQueriesListener
    
    public class NoStaleQueriesListener : IDocumentQueryListener
    {
        #region Implementation of IDocumentQueryListener
    
        public void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
        {
            queryCustomization.WaitForNonStaleResults();
        }
    
        #endregion
    }
    
    #endregion
