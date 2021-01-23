    Type myType = ...
    var constrs = myType
        .GetConstructors()
        .Where(c => c.GetParameters().Count()==1
        && c.GetParameters()[0].ParameterType.GetInterfaces().Contains(typeof(ISomeType))
        ).ToList();
    if (constrs.Count == 0) {
         // No constructors taking a class implementing ISomeType
    } else if (constrs.Count == 1) {
         // A single constructor taking a class implementing ISomeType
    } else {
         // Multiple constructors - you may need to go through them to decide
         // which one you would prefer to use.
    }
