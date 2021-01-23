    public static bool IsType(Type inputType, Type targetType)
    {
        if (inputType.IsGenericType)
        {
            Type[] genericArgs = inputType.GetGenericArguments();
            var foundType = false;
            foreach (var item in genericArgs)
            {
                if (IsType(item, targetType))
                    foundType = true;
            }
            return foundType;
        }
        return inputType.IsAssignableFrom(targetType);
    }
