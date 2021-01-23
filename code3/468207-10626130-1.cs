    public void Delete(IEntity e, World world) {
        if (typeof(IUndead).IsAssignableFrom(type)) undeadEntities.Remove(e);
        if (typeof(ILiving).IsAssignableFrom(type)) livingEntities.Remove(e);
        if (typeof(IObject).IsAssignableFrom(type)) objects.Remove(e);
    }
