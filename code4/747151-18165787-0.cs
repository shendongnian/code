    public class SeedFavoringRelay<T> : ISpecimenBuilder where T : class
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var seededRequest = request as SeededRequest;
            if (seededRequest == null || !seededRequest.Request.Equals(typeof(T)))
                return new NoSpecimen(request);
            var seed = seededRequest.Seed as T;
            if (seed == null)
                return new NoSpecimen(request);
            return seed;
        }
    }
