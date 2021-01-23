    public class BaseClass<TRequest, TResponse>
        where TRequest:RequestMessage,
              TResponse:ResponseMessage
    {
        public TRequest MapToRequest(XmlDocument xml)
        { return MapToModel<TRequest>(xml); }
        public TResponse MapToResponse(XmlDocument xml)
        { return MapToModel<TResponse>(xml); }
        private T MapToModel<T>(XmlDocument xml)
        {
            var mapper = new V3Mapper();
            return mapper.MapToDomainModel<T>(xml, Environment);        
        }
    }
    public GetEligibility : BaseClass<GetEligibilityRequestMessage, GetEligibilityResponseMessage>
    {}
