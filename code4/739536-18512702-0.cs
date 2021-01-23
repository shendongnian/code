    public class PassthroughExceptionHandlingBehavior : Attribute, IClientMessageInspector, IErrorHandler,
        IEndpointBehavior, IServiceBehavior, IContractBehavior
    {
        #region IClientMessageInspector Members
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                // Create a copy of the original reply to allow default processing of the message
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                Message copy = buffer.CreateMessage();  // Create a copy to work with
                reply = buffer.CreateMessage();         // Restore the original message
                var exception = ReadExceptionFromFaultDetail(copy) as Exception;
                if (exception != null)
                {
                    throw exception;
                }
            }
        }
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            return null;
        }
        private static object ReadExceptionFromFaultDetail(Message reply)
        {
            const string detailElementName = "detail";
            using (XmlDictionaryReader reader = reply.GetReaderAtBodyContents())
            {
                // Find <soap:Detail>
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && 
                        detailElementName.Equals(reader.LocalName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return ReadExceptionFromDetailNode(reader);
                    }
                }
                // Couldn't find it!
                return null;
            }
        }
        private static object ReadExceptionFromDetailNode(XmlDictionaryReader reader)
        {
            // Move to the contents of <soap:Detail>
            if (!reader.Read())
            {
                return null;
            }
            // Return the deserialized fault
            try
            {
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                return serializer.ReadObject(reader);
            }
            catch (SerializationException)
            {
                return null;
            }
        }
        #endregion
        #region IErrorHandler Members
        public bool HandleError(Exception error)
        {
            return false;
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error is FaultException)
            {
                // Let WCF do normal processing
            }
            else
            {
                // Generate fault message manually including the exception as the fault detail
                MessageFault messageFault = MessageFault.CreateFault(
                    new FaultCode("Sender"),
                    new FaultReason(error.Message),
                    error,
                    new NetDataContractSerializer());
                fault = Message.CreateMessage(version, messageFault, null);
            }
        }
        #endregion
        #region IContractBehavior Members
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ApplyClientBehavior(clientRuntime);
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            ApplyDispatchBehavior(dispatchRuntime.ChannelDispatcher);
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        #endregion
        #region IEndpointBehavior Members
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            ApplyClientBehavior(clientRuntime);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            ApplyDispatchBehavior(endpointDispatcher.ChannelDispatcher);
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        #endregion
        #region IServiceBehavior Members
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                ApplyDispatchBehavior(dispatcher);
            }
        }
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
        #endregion
        #region Behavior helpers
        private static void ApplyClientBehavior(System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            foreach (IClientMessageInspector messageInspector in clientRuntime.MessageInspectors)
            {
                if (messageInspector is PassthroughExceptionHandlingBehavior)
                {
                    return;
                }
            }
            clientRuntime.MessageInspectors.Add(new PassthroughExceptionHandlingBehavior());
        }
        private static void ApplyDispatchBehavior(System.ServiceModel.Dispatcher.ChannelDispatcher dispatcher)
        {
            // Don't add an error handler if it already exists
            foreach (IErrorHandler errorHandler in dispatcher.ErrorHandlers)
            {
                if (errorHandler is PassthroughExceptionHandlingBehavior)
                {
                    return;
                }
            }
            dispatcher.ErrorHandlers.Add(new PassthroughExceptionHandlingBehavior());
        }
        #endregion
    }
    #region PassthroughExceptionHandlingElement class
    public class PassthroughExceptionExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(PassthroughExceptionHandlingBehavior); }
        }
        protected override object CreateBehavior()
        {
            System.Diagnostics.Debugger.Launch();
            return new PassthroughExceptionHandlingBehavior();
        }
    }
    #endregion
