    public class IPFilterAttribute : Attribute, IOperationBehavior, IParameterInspector
    {
        private string _rangeFrom;
        private string _rangeTo;
        public IPFilterAttribute(string rangeFrom, string rangeTo)
        {
            _rangeFrom = rangeFrom;
            _rangeTo = rangeTo;
        }
        public void ApplyDispatchBehavior(
            OperationDescription operationDescription,
            DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }
        public void AfterCall(string operationName, object[] outputs,
                              object returnValue, object correlationState)
        {
        }
        public object BeforeCall(string operationName, object[] inputs)
        {
            RemoteEndpointMessageProperty clientEndpoint =
                OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if (!IsClientInInRange(clientEndpoint.Address))
            {
                throw new SecurityException(string.Format("Calling method '{0}' is not allowed from address '{1}'.", operationName, clientEndpoint.Address));
            }
            return null;
        }
        private bool IsClientInRange(string clientAddress)
        {
            // do the magic to check if client address is in the givn range
        }
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }
        public void Validate(OperationDescription operationDescription)
        {
        }
    }
