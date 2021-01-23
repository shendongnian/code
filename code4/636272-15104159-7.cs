    private T ModifyOnAccessDenied<T>(T propertyToChange)
    {
        if (!_hasAccess)
        {
            if (propertyToChange is string)
                return (dynamic)string.Empty;
            else if (propertyToChange is int)
                return (dynamic)(int)-1;
        }
        return propertyToChange;
    } 
