    public IQueryable<TModel> GetAll(ODataQueryOptions opts)
        {
            var db = _repo.GetAll();
            return (IQueryable<TModel>) opts.ApplyTo(db);
        }
