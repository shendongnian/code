    [QueryInterceptor("Entities")]
    public Expression<Func<Entity,bool>> OnQueryFares()
    {
        return e => DataCheck(e);
    }
