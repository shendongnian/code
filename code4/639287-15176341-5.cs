    public void RebuildIndices()
    {
        Logger.Info(i => i("Rebuilding the Full-Text indices..."));
        var entityTypes = GetIndexableTypes();
    
        if (entityTypes.Count() == 0) return;
        FullText.ClearIndices();
        foreach (var entityType in entityTypes)
        {
            var entityList = _Session.CreateCriteria(entityType).List();
            var populateIndexMethod = typeof(FullText).GetMethod("PopulateIndex", BindingFlags.Public | BindingFlags.Static);
            var typedPopulateIndexMethod = populateIndexMethod.MakeGenericMethod(entityType);
            typedPopulateIndexMethod.Invoke(null, new object[] { entityList });
        }
    }
