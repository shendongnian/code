    public class LifespanArg : ISpecimenBuilder
    {
        private readonly TimeSpan lifespan;
        public LifespanArg(TimeSpan lifespan)
        {
            this.lifespan = lifespan;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as ParameterInfo;
            if (pi == null)
                return new NoSpecimen(request);
            if (pi.ParameterType != typeof(TimeSpan) ||
                pi.Name != "lifespan")   
                return new NoSpecimen(request);
            return this.lifespan;
        }
    }
