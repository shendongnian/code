    public static T ReAttach<T>(DbContext context, T objectDetached,
        params object[] keyValues) where T : class
    {
        T original = context.Set<T>().Find(keyValues);
        if (original == null)
            throw new ObjectNotFoundException();
        context.Entry(original).CurrentValues.SetValues(objectDetached);
        return objectDetached;
    }
