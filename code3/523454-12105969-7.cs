    internal static List<Type> ReadTypesFromCache(string cacheName, Predicate<Type> predicate, IBuildManager buildManager, TypeCacheSerializer serializer)
    {
        try
        {
            Stream stream = buildManager.ReadCachedFile(cacheName);
            if (stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    List<Type> deserializedTypes = serializer.DeserializeTypes(reader);
                    if (deserializedTypes != null && deserializedTypes.All(type => TypeIsPublicClass(type) && predicate(type)))
                    {
                        // If all read types still match the predicate, success!
                        return deserializedTypes;
                    }
                }
            }
        }
        catch
        {
        }
        return null;
    }
