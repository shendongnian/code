    // Sample object with a property. 
    SomeClass someClass = new SomeClass{Property = "Value"};
    // Create the member expression.
    Expression<Func<object /*prop owner object*/, object/*prop value*/>> e =
        owner => ((SomeClass)owner).Property;
    
    // Get property name by analyzing expression.
    string propName = ((MemberExpression)e.Body).Member.Name;
    
    // Get property value by compiling and running expression.
    object propValue = e.Compile().Invoke(someClass);
