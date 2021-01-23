    var objSetProps = ctx.GetType().GetProperties().Where(prop => prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ObjectSet<>));
    foreach (PropertyInfo objSetProp in objSetProps)
    {
        ObjectQuery objSet = (ObjectQuery)objSetProp.GetValue(ctx, BindingFlags.GetProperty, null, null, null);
        objSet.MergeOption = MergeOption.PreserveChanges;
    }
