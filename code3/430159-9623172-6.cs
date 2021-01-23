    // Sample object with a property. 
    SomeClass someClass = new SomeClass{Property = "Value"};
    // Create the member expression.
    Expression<Func<object, object>> e = s => ((SomeClass)s).Property;
    
    // Get property name by evaluating expression.
    string propName = ((MemberExpression)e.Body).Member.Name;
    
    // Get property value by compiling and running expression.
    object propValue = e.Compile().Invoke(someClass);
