    var idPropertyType = currentEntityProperty.PropertyType.GetProperty("Id").GetType();
    var entityPropertyType = currentEntityProperty.PropertyType;
    var method = this.GetType().GetMethod("UpdateAllProperties", 
                                  BindingFlags.Instance | BindingFlags.NonPublic);
    var genericMethod = method.MakeGenericMethod(idPropertyType, entityPropertyType);
    genericMethod.Invoke(this, new[] { 
        currentEntityProperty.GetValue(currentEntity, null),   
        newEntityProperty.GetValue(newEntity, null)
    });
