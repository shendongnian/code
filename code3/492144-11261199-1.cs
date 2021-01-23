            private static bool OpenGenericIsAssignableFrom1(Type openGenericType, Type typeToCheck)
            {
                return typeToCheck != null && typeToCheck != typeof(Object) && // Terminate recursion
                    ((typeToCheck.IsGenericType && (typeToCheck.GetGenericTypeDefinition() == openGenericType)) || // typeToCheck is as closure of openGenericType
                    OpenGenericIsAssignableFrom(openGenericType, typeToCheck.BaseType) || // typeToCheck is the subclass of a closure of openGenericType
                    typeToCheck.GetInterfaces().Any(interfaceType => OpenGenericIsAssignableFrom(openGenericType, interfaceType))); // typeToCheck inherits from an interface which is the closure of openGenericType
            }
