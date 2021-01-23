    public IgnorableSerializerContractResolver Ignore<TModel>(Expression<Func<TModel, object>> selector)
    {
        MemberExpression body = selector.Body as MemberExpression;
        if (body == null)
        {
            UnaryExpression ubody = (UnaryExpression)selector.Body;
            body = ubody.Operand as MemberExpression;
                
            if (body == null)
            {
                throw new ArgumentException("Could not get property name", "selector");
            }
        }
        string propertyName = body.Member.Name;
        this.Ignore(typeof (TModel), propertyName);
        return this;
    }
