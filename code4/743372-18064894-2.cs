    public class MeasureServiceFactory : IMeasureService
    {
        private readonly Func<MeasureServiceType1> _type1Service;
        private readonly Func<MeasureServiceType2> _type2Service;
        public MeasureServiceFactory(
            Func<MeasureServiceType1> type1Service,
            Func<MeasureServiceType2> type2Service)
        {
            _type1Service = type1Service;
            _type2Service = type2Service;
        }
        public void Calculate(Measure measure)
        {
            var service = GetServiceForType(measure.measureType);
            service.Calculate(measure);
        }
        private IMeasureService GetServiceForType(MeasureType type)
        {
            switch (type)
            {
                case MeasureType.Type1:
                    return _type1Service();
                case MeasureType.Type2:
                    return _type2Service();
                default:
                    throw new ApplicationException("Unexpected measure type!");
            }
        }
    }
