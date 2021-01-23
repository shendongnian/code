    public class Program
    {
        public int Setting { get; set; }
    }
    [ServiceContract]
    public interface ISettingService
    {
        [OperationContract]
        void SetSetting(int setting);
    }
    public class SettingService : ISettingService
    {
        private readonly Program program;
        public SettingService(Program program)
        {
            this.program = program;
        }
        public void SetSetting(int setting)
        {
            program.Setting = setting;
        }
    }
    internal class CustomInstanceProvider : IInstanceProvider
    {
        private readonly Program program;
        public CustomInstanceProvider(Program program)
        {
            this.program = program;
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return new SettingService(program);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            IDisposable disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
    internal class CustomInstanceProviderBehaviorAttribute : Attribute, IServiceBehavior
    {
        private readonly IInstanceProvider instanceProvider;
        public CustomInstanceProviderBehaviorAttribute(IInstanceProvider instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher ed in cd.Endpoints)
                {
                    if (!ed.IsSystemEndpoint)
                    {
                        ed.DispatchRuntime.InstanceProvider = instanceProvider;
                    }
                }
            }
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
    public class CustomServiceHost : ServiceHost
    {
        private readonly Program p;
        public CustomServiceHost(Program program, params Uri[] baseAddresses)
        : base(typeof(SettingService), baseAddresses)
        {
            this.p = program;
        }
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new CustomInstanceProviderBehaviorAttribute(new CustomInstanceProvider(p)));
            base.OnOpening();
        }
    }
