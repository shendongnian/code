    internal class RandomDoublePrecisionFloatingPointSequenceGenerator
        : ISpecimenBuilder
    {
        private readonly object syncRoot;
        private readonly Random random;
        internal RandomDoublePrecisionFloatingPointSequenceGenerator()
        {
            this.syncRoot = new object();
            this.random = new Random();
        }
        public object Create(object request, ISpecimenContext context)
        {
            var type = request as Type;
            if (type == null)
                return new NoSpecimen(request);
            return this.CreateRandom(type);
        }
        private double GetNextRandom()
        {
            lock (this.syncRoot)
            {
                return this.random.NextDouble();
            }
        }
        private object CreateRandom(Type request)
        {
            switch (Type.GetTypeCode(request))
            {
                case TypeCode.Decimal:
                    return (decimal)
                        this.GetNextRandom();
                case TypeCode.Double:
                    return (double)
                        this.GetNextRandom();
                case TypeCode.Single:
                    return (float)
                        this.GetNextRandom();
                default:
                    return new NoSpecimen(request);
            }
        }
    }
