    private void InitializeNode(object context)
        {
            Type contextType = (context == null || context is Type ? context as Type : context.GetType());
            if (accessor == null || accessor.RequiresRefresh(contextType))
            {
                memberName = this.getText();
                // clear cached member info if context type has changed (for example, when ASP.NET page is recompiled)
                if (accessor != null && accessor.RequiresRefresh(contextType))
                {
                    accessor = null;
                }
                // initialize this node if necessary
                if (contextType != null && accessor == null)
                {//below is new IF;)
                    if (contextType == typeof(System.Dynamic.ExpandoObject))
                    {
                        accessor = new ExpandoObjectValueAccessor(memberName);
                    }
                    // try to initialize node as enum value first
                    else if (contextType.IsEnum)
                    {
                        try
                        {
                            accessor = new EnumValueAccessor(Enum.Parse(contextType, memberName, true));
                        }
                        catch (ArgumentException)
                        {
                            // ArgumentException will be thrown if specified member name is not a valid
                            // enum value for the context type. We should just ignore it and continue processing,
                            // because the specified member could be a property of a Type class (i.e. EnumType.FullName)
                        }
                    }
                    // then try to initialize node as property or field value
                    if (accessor == null)
                    {
                        // check the context type first
                        accessor = GetPropertyOrFieldAccessor(contextType, memberName, BINDING_FLAGS);
                        // if not found, probe the Type type
                        if (accessor == null && context is Type)
                        {
                            accessor = GetPropertyOrFieldAccessor(typeof(Type), memberName, BINDING_FLAGS);
                        }
                    }
                }
                // if there is still no match, try to initialize node as type accessor
                if (accessor == null)
                {
                    try
                    {
                        accessor = new TypeValueAccessor(TypeResolutionUtils.ResolveType(memberName));
                    }
                    catch (TypeLoadException)
                    {
                        if (context == null)
                        {
                            throw new NullValueInNestedPathException("Cannot initialize property or field node '" +
                                                                     memberName +
                                                                     "' because the specified context is null.");
                        }
                        else
                        {
                            throw new InvalidPropertyException(contextType, memberName,
                                                               "'" + memberName +
                                                               "' node cannot be resolved for the specified context [" +
                                                               context + "].");
                        }
                    }
                }
            }
        }
