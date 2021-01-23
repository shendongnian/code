    private bool mapCreated = false;
    public virtual void InsertOrUpdate(T e, int id)
    {
        T instance = context.Set<T>().Create();
        if (e.GetType().Equals(instance.GetType()))
            instance = e;
        else
        {
            if (!mapCreated)
            {
                Mapper.CreateMap(e.GetType(), instance.GetType());
                mapCreated = true;
            }
            instance = Mapper.Map(e, instance);
        }
        if (id == default(int))
            context.Set<T>().Add(instance);
        else
            context.Entry(instance).State = EntityState.Modified;
    }
