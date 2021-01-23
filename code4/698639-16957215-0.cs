    public class ParameterNameSpecimenBuilder<T> : ISpecimenBuilder
    {
        private readonly string name;
        private readonly T value;
        public ParameterNameSpecimenBuilder(string name, T value)
        {
            // we don't want a null name but we might want a null value
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }
            this.name = name;
            this.value = value;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null)
            {
                return new NoSpecimen(request);
            }
            if (pi.ParameterType != typeof(T) ||
                !string.Equals(
                    pi.Name, 
                    this.name, 
                    StringComparison.CurrentCultureIgnoreCase))
            {
                return new NoSpecimen(request);
            }
            return this.value;
        }
    }
