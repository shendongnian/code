    private void UpdateAllProperties<idType, entityType>(entityType currentEntity, entityType newEntity)
        where idType : IEquatable<idType>
        where entityType : AbstractEntity<idType>
    {
        var currentEntityProperties = currentEntity.GetType().GetProperties();
        var newEntityProperties = newEntity.GetType().GetProperties();
        foreach (var currentEntityProperty in currentEntityProperties)
        {
            foreach (var newEntityProperty in newEntityProperties)
            {
                if (newEntityProperty.Name == currentEntityProperty.Name)
                {
                    if (currentEntityProperty.PropertyType.BaseType.IsGenericType &&
                        currentEntityProperty.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(AbstractEntity<>))
                    {
                        var idPropertyType = currentEntityProperty.PropertyType.GetProperty("Id").PropertyType;
                        var entityPropertyType = currentEntityProperty.PropertyType;
                        this.InvokeUpdateAllProperties(currentEntityProperty.GetValue(currentEntity, null),
                                                        newEntityProperty.GetValue(newEntity, null),
                                                        idPropertyType, entityPropertyType);
                        break;
                    }
                    else if (currentEntityProperty.PropertyType.GetInterfaces().Any(
                                x => x.IsGenericType &&
                                        x.GetGenericTypeDefinition() == typeof(ICollection<>)))
                    {
                        dynamic currentCollection = currentEntityProperty.GetValue(currentEntity, null);
                        dynamic newCollection = newEntityProperty.GetValue(newEntity, null);
                        this.UpdateCollectionItems(currentEntityProperty, currentCollection, newCollection);
                        dynamic itemsToRemove = Enumerable.ToList(Enumerable.Except(currentCollection, newCollection));
                        dynamic itemsToAdd = Enumerable.ToList(Enumerable.Except(newCollection, currentCollection));
                        dynamic itemsAreEqual = Enumerable.ToList(Enumerable.Intersect(currentCollection, newCollection));
                        for (int i = 0; i < itemsToRemove.Count; i++)
                        {
                            currentCollection.Remove(Enumerable.ElementAt(itemsToRemove, i));
                        }
                        for (int i = 0; i < itemsToAdd.Count; i++)
                        {
                            currentCollection.Add(Enumerable.ElementAt(itemsToAdd, i));
                        }
                        break;
                    }
                    else
                    {
                        currentEntityProperty.SetValue(currentEntity, newEntityProperty.GetValue(newEntity, null), null);
                        break;
                    }
                }
            }
        }
    }
    private void UpdateCollectionItems(PropertyInfo currentEntityProperty, dynamic currentCollection, dynamic newCollection)
    {
        var collectionType = currentEntityProperty.PropertyType.GetInterfaces().Where(
                                x => x.IsGenericType &&
                                        x.GetGenericTypeDefinition() == typeof(ICollection<>)).First();
        var argumentType = collectionType.GetGenericArguments()[0];
        if (argumentType.BaseType.IsGenericType &&
            argumentType.BaseType.GetGenericTypeDefinition() == typeof(AbstractEntity<>))
        {
            foreach (var currentItem in currentCollection)
            {
                foreach (var newItem in newCollection)
                {
                    if (currentItem.Equals(newItem))
                    {
                        var idPropertyType = currentItem.GetType().GetProperty("Id").PropertyType;
                        var entityPropertyType = currentItem.GetType();
                        this.InvokeUpdateAllProperties(currentItem, newItem, idPropertyType, entityPropertyType);
                    }
                }
            }
        }
    }
    private void InvokeUpdateAllProperties(dynamic currentEntity, dynamic newEntity, dynamic idPropertyType, dynamic entityPropertyType)
    {
        var method = this.GetType().GetMethod("UpdateAllProperties", BindingFlags.Instance | BindingFlags.NonPublic);
        var genericMethod = method.MakeGenericMethod(idPropertyType, entityPropertyType);
        genericMethod.Invoke(this, new[] { currentEntity, newEntity });
    }
