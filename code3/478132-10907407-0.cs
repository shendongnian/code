    public class BaseClass
    {
        private readonly Type _requestType;
        private readonly Type _responseType;
        protected BaseClass(Type requestType, Type responseType)
        {
            _requestType = requestType;
            _responseType = responseType;
        }
        public T MapToModel<T>(XmlDocument xml)
        {
            if (typeof(T) != _requestType && typeof(T) != _responseType)
                throw new InvalidOperationException("Invalid type");
            var mapper = new V3Mapper();
            return mapper.MapToDomainModel<T>(xml, Environment);
        }
    }
    public GetEligibility : BaseClass
    {
        public GetEligibility() 
            : base(typeof(GetEligibilityRequestMessage), typeof(GetEligibilityResponseMessage))
        {}
    }
