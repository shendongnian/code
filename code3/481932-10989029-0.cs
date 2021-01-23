    public TInterface Get(long id)
    {
        return Invoke(
            context =>
            {
                TDto dto = context.Set<TDto>().Include(t => t.Type)
                      .FirstOrDefault(x => (x.Id == id));
                return dto.Convert<TDto, TInterface>();
            }
        );
    }
