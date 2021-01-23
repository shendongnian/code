    public LinkedList<IEntity> GetList(Type type) {
        if (typeof(IUndead).IsAssignableFrom(type)) return undeadEntities;
        if (typeof(ILiving).IsAssignableFrom(type)) return livingEntities;
        if (typeof(IObject).IsAssignableFrom(type)) return objects;
    }
