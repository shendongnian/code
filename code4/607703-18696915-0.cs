    public static void EnableCollectionSynchronization(IEnumerable collection, object lockObject)
    {
        // Equivalent to .NET 4.5:
        // BindingOperations.EnableCollectionSynchronization(collection, lockObject);
        MethodInfo method = typeof(BindingOperations).GetMethod("EnableCollectionSynchronization", new Type[] { typeof(IEnumerable), typeof(object) });
        if (method != null)
        {
            method.Invoke(null, new object[] { collection, lockObject });
        }
    }
