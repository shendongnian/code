    public static IUnityContainer Initialise(IUnityContainer container = null)
    {
        if (container == null)
        {
            container = new UnityContainer();
        }
        container.RegisterType<ISettingsManager, SettingsManager>();
        container.Resolve<SettingsManager>();
        container.RegisterType<SettingsManagerController>(new InjectionProperty("_SettingManagerProvider", new ResolvedParameter<ISettingManager>()));
        return container;
    }
