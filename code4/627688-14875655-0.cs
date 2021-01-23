    public bool IsMultiSlot(object entity)
    {
      Type type = entity.GetType();
      if (!type.IsGenericType)
        return false;
      if (type.GetGenericTypeDefinition() == typeof(MultiSlot<>))
        return true;
      return false;
    }
