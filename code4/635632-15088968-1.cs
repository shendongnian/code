    private Generic GetEntityValue<Generic>(
      Entity entity, String field, Generic substitute = default(Generic))
    {
      if (entity.Contains(field))
        return (Generic)entity[field];
      return substitute;
    }
