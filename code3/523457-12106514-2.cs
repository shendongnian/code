    public static List<Type> GetFilteredTypesFromAssemblies(string cacheName, Predicate<Type> predicate, IBuildManager buildManager) {
        TypeCacheSerializer serializer = new TypeCacheSerializer();
        // first, try reading from the cache on disk
        List<Type> matchingTypes = ReadTypesFromCache(cacheName, predicate, buildManager, serializer);
        if (matchingTypes != null) {
            return matchingTypes;
        }
        // if reading from the cache failed, enumerate over every assembly looking for a matching type
        matchingTypes = FilterTypesInAssemblies(buildManager, predicate).ToList();
        // finally, save the cache back to disk
        SaveTypesToCache(cacheName, matchingTypes, buildManager, serializer);
        return matchingTypes;
    }
