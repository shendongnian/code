    public class OmitPropertyForTypeInNamespace : ISpecimenBuilder
    {
        private readonly string ns;
        public OmitPropertyForTypeInNamespace(string ns)
        {
            this.ns = ns;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (IsProperty(request) &&
                IsDeclaringTypeInNamespace((PropertyInfo)request))
            {
                return new OmitSpecimen();
            }
            return new NoSpecimen(request);
        }
        private bool IsProperty(object request)
        {
            return request is PropertyInfo;
        }
        private bool IsDeclaringTypeInNamespace(PropertyInfo property)
        {
            var declaringType = property.DeclaringType;
            return declaringType.Namespace.Equals(ns, StringComparison.OrdinalIgnoreCase);
        }
    }
