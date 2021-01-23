    // example - create one specification
    Expression<Func<T, bool>> expression =  ....;  
    ISpecification<Foo> fooSpecification = new Specification<Foo>(expression);
    
    
    // using the specification with linq
    var entities = dbContext.Foos.Where(fooSpecification.GetExpression());
    
    
    // performing validation
    var foo = new Foo{
        // ....
    };
    
    if(fooSpecification.IsSatisfiedBy(foo))
    {
        // do something....
    }
