            // create dynamic type
            var properties = typeof(Pet).GetProperties().Where(pi => pi.Name == "Name"); //will be defined by user
            var dynamicType = CreateType(properties);
            // build expression
            var list = new List<Pet>();
            var eList = Expression.Constant(list);
            var pe = Expression.Parameter(typeof(Pet), "p");
            var createObjectMethod = typeof(Program).GetMethod("CreateObject", BindingFlags.Static | BindingFlags.NonPublic);
            var createObjectCall = Expression.Call(createObjectMethod, Expression.Constant(properties));
            var castExpression = Expression.Convert(createObjectCall, dynamicType);
            var selectorExpression = Expression.Lambda(castExpression, pe);
            var res = Expression.Call(typeof(Enumerable), "Select", new[] { typeof(Pet), dynamicType }, eList, selectorExpression);
