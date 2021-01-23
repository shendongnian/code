    Type GetBaseTypeOfEnumerable(IEnumerable enumerable)
    {
        if (enumerable == null)
        {
            //you'll have to decide what to do in this case
        }
        var genericEnumerableInterface = enumerable
            .GetType()
            .GetInterfaces()
            .Where(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .FirstOrDefault();
        if (genericEnumerableInterface == null)
        {
            //If we're in this block, the type implements IEnumerable, but not IEnumerable<T>;
            //you'll have to decide what to do here.
            //Justin Harvey's (now deleted) answer suggested enumerating the 
            //enumerable and examining the type of its elements; this 
            //is a good idea, but keep in mind that you might have a
            //mixed collection.
        }
        var elementType = genericEnumerableInterface.GetGenericArguments()[0];
        return elementType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? elementType.GetGenericArguments[0]
            : elementType;
    }
