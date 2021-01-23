    public ComposablePartDefinition GetPartDefinition(string ContractName) {
       return _provider.Catalog.Parts
                       .Where(p => p.ExportDefinitions
                                    .Select(e => e.ContractName)
                                    .Any(c => c == ContractName))
                       .FirstOrDefault();
    }
