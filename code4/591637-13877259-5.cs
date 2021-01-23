    public static int InsertOrReplace(IDataContextInfo dataContextInfo, T obj)
    {
        ...
        else if (field.IsIdentity)
        {
            throw new LinqException("InsertOrUpdate method does not support identity field '{0}.{1}'.", sqlTable.Name, field.Name);
        }
        ...
    }
