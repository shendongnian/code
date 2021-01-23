    public class DiscriminatorValueConvention : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            instance.DiscriminatorValue(instance.EntityType.Name);
        }
    }
