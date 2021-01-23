    object obj = new Customer();
    Type ty = obj.GetType();
    MethodInfo validatorFactory = valFactory.GetType()
                                   .GetMethod("CreateValidator")
                                   .MakeGenericType(ty);
    var cusValidator = validatorFactory.Invoke(valFactory, null);
