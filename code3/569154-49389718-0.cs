    private void SetApiSettingValue(object source, string propertyName, object valueToSet)
    {
        // find out the type
        Type type = source.GetType();
        // get the property information based on the type
        System.Reflection.PropertyInfo property = type.GetProperty(propertyName);
        // Convert.ChangeType does not handle conversion to nullable types
        // if the property type is nullable, we need to get the underlying type of the property
        Type propertyType = property.PropertyType;
        var targetType = IsNullableType(propertyType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;
        // special case for enums
        if (targetType.IsEnum)
        {
            // we could be going from an int -> enum so specifically let
            // the Enum object take care of this conversion
            if (valueToSet != null)
            {
                valueToSet = Enum.ToObject(targetType, valueToSet);
            }
        }
        else
        {
            // returns an System.Object with the specified System.Type and whose value is
            // equivalent to the specified object.
            valueToSet = Convert.ChangeType(valueToSet, targetType);
        }
        // set the value of the property
        property.SetValue(source, valueToSet, null);
    }
    private bool IsNullableType(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
    }
