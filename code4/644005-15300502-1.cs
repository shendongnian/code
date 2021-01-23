        var sourceType = typeof(Journal);
        // define a dynamic type (read: anonymous type) for our needs
        var dynAsm = AppDomain
            .CurrentDomain
            .DefineDynamicAssembly(
                new AssemblyName(Guid.NewGuid().ToString()), 
                AssemblyBuilderAccess.Run);
        var dynMod = dynAsm
             .DefineDynamicModule(Guid.NewGuid().ToString());
        var typeBuilder = dynMod
             .DefineType(Guid.NewGuid().ToString());
        var properties = groupByNames
            .Select(name => sourceType.GetProperty(name))
            .Cast<MemberInfo>();
        var fields = groupByNames
            .Select(name => sourceType.GetField(name))
            .Cast<MemberInfo>();
        var propFields = properties
            .Concat(fields)
            .Where(pf => pf != null);
        foreach (var propField in propFields)
        {        
            typeBuilder.DefineField(
                propField.Name, 
                propField.MemberType == MemberTypes.Field 
                    ? (propField as FieldInfo).FieldType 
                    : (propField as PropertyInfo).PropertyType, 
                FieldAttributes.Public);
        }
        var dynamicType = typeBuilder.CreateType();
