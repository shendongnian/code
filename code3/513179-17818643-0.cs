    public IEnumerator<T> GetEnumerator() {
    
        // For my case (a custom object-oriented database engine) I still 
        // have an IQueryProvider which builds a "subset" of objects each populated 
        // with only "required" fields, as extracted from the expression. IDs, 
        // dates, particular strings, what have you. This is "cheap" because it 
        // has an indexing system as well.
    
        var en = ((IEnumerable<T>)this.provider.Execute(this.expression));
        
        // Copy your internal objects into a list.
    
        var ar = new List<T>(en);
        var queryable = ar.AsQueryable<T>();
        // This is where we went wrong:
        // queryable.Provider.CreateQuery(this.expression);
        // We can't re-reference the original expression because it will loop 
        // right back on our custom IQueryable<>. Instead, swap out the first 
        // argument with the List's queryable:
    
        var mc = (MethodCallExpression)this.expression;
        var exp = Expression.Call(mc.Method, 
                        Expression.Constant(queryable), 
                        mc.Arguments[1]);
        // Now the CLR can do all of the heavy lifting
        var query = queryable.Provider.CreateQuery<T>(exp);
        return query.GetEnumerator();
    }
