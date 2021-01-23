    public static class Ext
    {
        // Science Fact: the "Grouper" (as in the Fish) is classified as:
        //   Perciformes Serranidae Epinephelinae
        public static Expression<Func<T, object>> Epinephelinae<T>(
             this IEnumerable<T> source, 
             string [] groupByNames)
        {
            var sourceType = typeof(T);
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
    
            // Create and return an expression that maps T => dynamic type
            var sourceItem = Expression.Parameter(sourceType, "item");
            var bindings = dynamicType
                .GetFields()
                .Select(p => Expression.Bind(
                        p, 
                        Expression.PropertyOrField(sourceItem, p.Name)))
                .OfType<MemberBinding>()
                .ToArray();
    
            var fetcher = Expression.Lambda<Func<T, object>>(
                Expression.Convert(
                    Expression.MemberInit(
                        Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)),
                        bindings), 
                    typeof(object)),
                sourceItem);                
            return fetcher;
        }
    }
