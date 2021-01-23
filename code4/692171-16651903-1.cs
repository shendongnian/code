    public static T ReAttach<T>(DbContext context, T objectDetached)
        where T : class, IEntity
    {
        T original = context.Set<T>().Find(objectDetached.Id);
        if (original == null)
            throw new ObjectNotFoundException();
        context.Entry(original).CurrentValues.SetValues(objectDetached);
        return objectDetached;
    }
