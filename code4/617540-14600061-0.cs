    public IEnumerable<T> Find<TValue>(Expression<Func<T, TValue>> expression,
                                       TValue value)
    {
        using (IDbConnection cn = GetCn())
        {
            cn.Open();
            var predicate = Predicates.Field<T>(expression, Operator.Eq, value);
            return cn.GetList<T>(predicate);
        }
    }
