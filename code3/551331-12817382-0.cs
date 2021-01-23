    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        var settings = new BootstrapSettings(_bootstrapSettingsPath);
        builder.RegisterInstance(settings)
            .As<IBootstrapSettings>()
            .SingleInstance();
        var encryptorType = Type.GetType(settings.Get("encryptionprovider"));
        builder.RegisterType(encryptorType)
            .As<IEncryptor>()
            .SingleInstance();
    }
