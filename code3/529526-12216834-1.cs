    var type = typeof(IRoadVehicle);
    
    var accessors = type.GetProperties().SelectMany(property => property.GetAccessors());
    var methods = type.GetMethods()
                      .Except(accessors);
