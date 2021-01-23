    public void EnsureInitialized(IBuildManager buildManager) {
        if (_cache == null) {
            lock (_lockObj) {
                if (_cache == null) {
                    List<Type> controllerTypes = TypeCacheUtil.GetFilteredTypesFromAssemblies(_typeCacheName, IsControllerType, buildManager);
                    var groupedByName = controllerTypes.GroupBy(
                        t => t.Name.Substring(0, t.Name.Length - "Controller".Length),
                        StringComparer.OrdinalIgnoreCase);
                    _cache = groupedByName.ToDictionary(
                        g => g.Key,
                        g => g.ToLookup(t => t.Namespace ?? String.Empty, StringComparer.OrdinalIgnoreCase),
                        StringComparer.OrdinalIgnoreCase);
                }
            }
        }
    }
