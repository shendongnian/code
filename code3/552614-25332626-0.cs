     public static bool DeleteCheckOnEntity(object entity)
       {
         var propertiesList = entity.GetType().GetProperties();
         return (from prop in propertiesList where prop.PropertyType.IsGenericType select prop.GetValue(entity) into propValue select propValue as IList).All(propList => propList == null || propList.Count <= 0);
       }
