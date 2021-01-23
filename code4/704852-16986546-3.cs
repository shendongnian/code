    public T GetSingle(IRepository<T> repository, Expression<Func<T, T, bool>> predicate, T entity)
    {
        //Create a new representation of predicate that will take just one parameter and capture entity
        //Get just the body of the supplied expression
        var body = predicate.Body;
        //Make a new visitor to replace the second parameter with the supplied value
        var substitutionVisitor = new VariableSubstitutionVisitor(predicate.Parameters[1], Expression.Constant(entity, typeof(T)));
        //Create an expression that represents the predicate with the second parameter replaced with the supplied entity
        var visitedBody = substitutionVisitor.Visit(body).Reduce();
        //Make the new expression into something that could be a Func<T, bool>
        var newBody = Expression.Lambda<Func<T, bool>>(visitedBody, predicate.Parameters[0]); 
            
        //Now, create something that will call Enumerable.Single on the result of GetAll from the repository, supplying the new predicate
        //Make a place to hold the result of GetAll
        var resultsParameter = Expression.Parameter(typeof (IEnumerable<T>));
        //Make an expression that calls the Single extension method
        var singleExpression = Expression.Call(((Func<IEnumerable<T>, Func<T, bool>, T>)Enumerable.Single).Method, resultsParameter, newBody);
        //Make a Func<IEnumerable<T>, T> that return the result of the call of Single on the results of the GetAll method
        var compiled = Expression.Lambda<Func<IEnumerable<T>, T>>(singleExpression, resultsParameter).Compile();
        //Call GetAll, letting the new method that we've got run the supplied predicate without having to run an Invoke type expression
        return compiled(repository.GetAll()); 
    }
