    public IEnumerable<Type> GetTypeArgumentsFrom(IEnumerable<IInterface> objects) {
        foreach (var obj in objects) {
            if (null == obj) {
                yield return null; // just a convention 
                                   // you return null if the object was null
                continue;
            }
            var type = obj.GetType();
            if (!type.IsGenericType) {
                yield return null;
                continue;
            }
            
            yield return type.GetGenericArguments()[0];
        }
    }
