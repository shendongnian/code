    public class UnityInterfaceInterceptionRegisterer : UnityContainerExtension
    {
        private List<Type> interfaces = new List<Type>();
        private List<IInterceptionBehavior> behaviors = 
            new List<IInterceptionBehavior>();
        public UnityInterfaceInterceptionRegisterer(Type interfaceType, 
            IInterceptionBehavior interceptionBehavior)
        {
            interfaces.Add(interfaceType);
            behaviors.Add(interceptionBehavior);
        }
        public UnityInterfaceInterceptionRegisterer(Type[] interfaces, 
            IInterceptionBehavior[] interceptionBehaviors)
        {            
            this.interfaces.AddRange(interfaces);
            this.behaviors.AddRange(interceptionBehaviors);
            ValidateInterfaces(this.interfaces);
        }
        protected override void Initialize()
        {
            base.Container.AddNewExtension<Interception>();
            base.Context.Registering += 
                new EventHandler<RegisterEventArgs>(this.OnRegister);
        }
        private void ValidateInterfaces(List<Type> interfaces)
        {
            interfaces.ForEach((i) =>
            {
                if (!i.IsInterface)
                    throw new ArgumentException("Only interface types may be configured for interface interceptors");
            }
            );
        }
        private bool ShouldIntercept(RegisterEventArgs e)
        {
            return e != null && e.TypeFrom != null && 
                   e.TypeFrom.IsInterface && interfaces.Contains(e.TypeFrom);
        }
        private void OnRegister(object sender, RegisterEventArgs e)
        {
            if (ShouldIntercept(e))
            {
                IUnityContainer container = sender as IUnityContainer;
                
                var i = new Interceptor<InterfaceInterceptor>();
                i.AddPolicies(e.TypeFrom, e.TypeTo, e.Name, Context.Policies);
                behaviors.ForEach( (b) =>
                    {
                        var ib = new InterceptionBehavior(b);
                        ib.AddPolicies(e.TypeFrom, e.TypeTo, e.Name, Context.Policies);
                    }
                );
            }
        }
    }
