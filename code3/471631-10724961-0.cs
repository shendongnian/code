    public class ErrorSavingServiceBahavior : BehaviorExtensionElement, IServiceBehavior, IErrorHandler
    {
        private string m_sHostName;
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            this.m_sHostName = serviceHostBase.Description.Name;
            foreach (ChannelDispatcher chanDisp in serviceHostBase.ChannelDispatchers)
            {
                if (!chanDisp.ErrorHandlers.Contains(this))
                {
                    chanDisp.ErrorHandlers.Add(this);
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
        public bool HandleError(Exception error)
        {
            //my custom code
        }
        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            //my custom code
        }
        public override Type BehaviorType
        {
            get { return this.GetType(); }
        }
        protected override object CreateBehavior()
        {
            return this;
        }
    }
