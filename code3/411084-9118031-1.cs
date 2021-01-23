    using NServiceBus
    using NServiceBus.Installation.Environments
    ...
    Bus = Configure.With()
        .Log4Net()
        .DefaultBuilder()
        .XmlSerializer()
        .MsmqTransport()
        .IsTransactional(false)
        .PurgeOnStartup(false)
        .UnicastBus()
        .ImpersonateSender(false)
        .CreateBus()
        .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
