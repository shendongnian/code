        private static bool OpenGenericIsAssignableFrom(
            Type openGenericType, 
            Type typeToCheck,
            out Type genericAssignableFrom)
        {
            genericAssignableFrom = null;
            while (typeToCheck != typeof(Object))
            {
                if (typeToCheck.IsGenericType)
                {
                    var typeArgs = typeToCheck.GetGenericArguments();
                    // We  need to close the generic to use IsAssignableFrom in the manner desired
                    if (typeArgs.Count() == openGenericType.GetGenericArguments().Count() && 
                        openGenericType.MakeGenericType(typeArgs).IsAssignableFrom(typeToCheck))
                    {
                        genericAssignableFrom = typeToCheck;
                        return true;
                    }
                }
                typeToCheck = typeToCheck.BaseType;
            }
            return false;
        }
