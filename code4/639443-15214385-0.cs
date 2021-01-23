    public class HasManyConventions : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance target)
        {
            target.Key.Column(target.EntityType.Name + "Id");
        }
    }
