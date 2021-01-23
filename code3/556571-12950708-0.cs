    protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                try
                {
                    IUnityContainer container = new UnityContainer();
                    container.RegisterType<ILogWriter, LogWriter>();
                    container.RegisterType<ExceptionManager>();
                    container.RegisterType<Performance>(new InjectionConstructor(typeof(ILogWriter), typeof(ExceptionManager));                    
                    Performance p = container.Resolve<Performance>();
                }
                catch (Exception ex)
                {
    
                }
            }
