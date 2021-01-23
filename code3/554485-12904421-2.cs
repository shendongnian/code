    internal override bool CheckIfNavigationPropertyContainsEntity(IEntityWrapper wrapper)
    {
        if (base.TargetAccessor.HasProperty)
        {
            object navigationPropertyValue = base.WrappedOwner.GetNavigationPropertyValue(this);
            if (navigationPropertyValue != null)
            {
                if (!(navigationPropertyValue is IEnumerable))
                {
                    throw new EntityException(Strings.ObjectStateEntry_UnableToEnumerateCollection(base.TargetAccessor.PropertyName, base.WrappedOwner.Entity.GetType().FullName));
                }
                foreach (object obj3 in navigationPropertyValue as IEnumerable)
                {
                    if (object.Equals(obj3, wrapper.Entity))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
