    public class CollectionPropertyOmitter : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null
                && pi.PropertyType.IsGenericType
                && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                return new OmitSpecimen();
            return new NoSpecimen(request);
        }
    }
