    public class Measure
    {
        public MeasureType measureType { get; set; }
        private readonly MeasureServiceFactory _measureServiceFactory;
        public Measure(MeasureServiceFactory measureServiceFactory)
        {
            _measureServiceFactory = measureServiceFactory;
        }
        public void Calculate()
        {
            var service = _measureServiceFactory.GetServiceForType(measureType);
            service.Calculate(this);
        }
    }
