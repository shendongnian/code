    public static Boolean PurgeDataObject(this IDataObject dataObject, Guid uid)
    {
        return PurgeDataObjectImpl((dynamic) dataObject, uid);
    }
    private static Boolean PurgeDataObjectImpl<T>(T dataObject, Guid uid)
        where T : IDataObject
    {
        return DataProvider.DeleteDataObject<T>(uid, DataProvider.GetConnection());
    }
