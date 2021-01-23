        this._assemblyCatalogs = new Dictionary<string, AssemblyCatalog>();
        this._catalogCollection = new ComposablePartCatalogCollection(null, null, null);
        this._loadedFiles = GetFiles().ToReadOnlyCollection();
        foreach (string file in this._loadedFiles)
        {
            AssemblyCatalog assemblyCatalog = null;
            assemblyCatalog = CreateAssemblyCatalogGuarded(file);
            if (assemblyCatalog != null)
            {
                this._assemblyCatalogs.Add(file, assemblyCatalog);
                this._catalogCollection.Add(assemblyCatalog);
            }
        }
