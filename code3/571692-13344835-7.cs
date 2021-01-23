    public static void ConstrainParameterType(Type parameterType, GenericConstraint constraintType, params Type[] allowedTypes)
            {
                if (constraintType == GenericConstraint.ExactType)
                {
                    if (!allowedTypes.Contains<Type>(parameterType))
                    {
                        throw new Exception("A runtime constraint disallows use of type " + parameterType.Name + " with this parameter.");
                    }
                }
                else
                {
                    foreach (Type constraint in allowedTypes)
                    {
                        if (!constraint.IsAssignableFrom(parameterType))
                        {
                            throw new Exception("A runtime constraint disallows use of type " + parameterType.Name + " with this parameter.");
                        }
                    }
                }
            }
    
    public enum GenericConstraint
        {
            /// <summary>
            /// The type must be exact.
            /// </summary>
            ExactType,
    
            /// <summary>
            /// The type must be assignable.
            /// </summary>
            AssignableType
        }
