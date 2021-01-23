    internal class StatusGenerator : ISpecimenBuilder
    {
        private readonly Status[] values;
        private int i;
        internal StatusGenerator()
        {
            this.values =
                Enum.GetValues(typeof(Status)).Cast<Status>().ToArray();
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null || !pi.ParameterType.IsEnum)
                return new NoSpecimen(request);
            return this.values[i == this.values.Length - 1 ? i = 0 : ++i];
        }
    }
