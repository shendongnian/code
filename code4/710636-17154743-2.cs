    public class JsonErrorHandlerBehaviorAttribute : Attribute, IErrorHandler, IServiceBehavior
    {
        public bool HandleError(Exception error)
        {
            //Log the error
            return true;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var fd = new JsonFaultDetail();
            fd.Message = error.Message;
            fault = Message.CreateMessage(version, string.Empty, fd, new DataContractJsonSerializer(fd.GetType()));
            var jsonFormatting = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, jsonFormatting);
            var httpResponse = new HttpResponseMessageProperty()
            {
                StatusCode = HttpStatusCode.InternalServerError,
            };
            fault.Properties.Add(HttpResponseMessageProperty.Name, httpResponse);
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            return;
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                if (dispatcher.BindingName.Contains("WebHttpBinding"))
                    dispatcher.ErrorHandlers.Add(this);
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
