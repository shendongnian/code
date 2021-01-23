    internal static void ChangeCode<T>(Entity entity) where T : Entity
    {
        Entity tempEntity;
    
        if (entity.GetType() == typeof(SomeMoreSpecificEntity))
        {
            tempEntity = new SomeMoreSpecificEntity();
        }
    }
