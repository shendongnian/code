    public TProperty Foo<TProperty>( Expression<Func<TInput, TProperty>> propertyToGet ) {
        string propertyToGetName = ( (MemberExpression)propertyToGet.Body ).Member.Name;
        // do something with the property name
        // and/or evaluate the expression and get the value of the property
    }
