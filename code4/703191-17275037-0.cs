    // Handy extension methods for dealing with CompositionScopeDefinition (Not relevant to this answer but useful).
    public static class ComposablePartCatalogExtensions
    {
        public static CompositionScopeDefinition AsScope(this ComposablePartCatalog catalog, params CompositionScopeDefinition[] children)
        {
            return new CompositionScopeDefinition(catalog, children);
        }
        
        public static CompositionScopeDefinition AsScopeWithPublicSurface<T>(this ComposablePartCatalog catalog, params CompositionScopeDefinition[] children)
        {
            IEnumerable<ExportDefinition> definitions = catalog.Parts.SelectMany((p) => p.ExportDefinitions.Where((e) => e.ContractName == AttributedModelServices.GetContractName(typeof(T))));
            return new CompositionScopeDefinition(catalog, children, definitions);
        }
    }
        
    AggregateCatalog aggregateCatalog = new AggregateCatalog();
    AggregateCatalog childAggregateCatalog = new AggregateCatalog();
    CompositionScopeDefinition compositionScopeDefinition = aggregateCatalog.AsScope(childAggregateCatalog.AsScope());
    CompositionContainer compositionContainer = new CompositionContainer(compositionScopeDefinition);
        
    TypeCatalog globalParts = new TypeCatalog(typeof(RequestListener));
    TypeCatalog scopedParts = new TypeCatalog(typeof(RequestHandler), typeof(DataAccessLayer), typeof(Logger), typeof(DatabaseConnection));
        
    aggregateCatalog.Catalogs.Add(globalParts);
    childAggregateCatalog.Catalogs.Add(scopedParts);
        
    RequestListener requestListener = compositionContainer.GetExportedValue<RequestListener>();
