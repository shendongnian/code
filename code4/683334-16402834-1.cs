        public static bool IsOrInheritsGenericDefinition(this Type ThisType, Type GenericDefinition, out Type DefinitionWithTypedParameters)
        {
            DefinitionWithTypedParameters = ThisType;
            while (DefinitionWithTypedParameters != null)
            {
                if (DefinitionWithTypedParameters.IsGenericType)
                {
                    if (DefinitionWithTypedParameters.GetGenericTypeDefinition() == GenericDefinition)
                        return true;
                }
                DefinitionWithTypedParameters = DefinitionWithTypedParameters.BaseType;
            }
            return false;
        }
