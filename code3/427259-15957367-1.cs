    public partial class App : Application
    {
      public static IBus Bus { get; private set; }
      protected override void OnStartup(StartupEventArgs e)
      {
         base.OnStartup(e);
         Bus = NServiceBus.Configure.With()
             .DefineEndpointName("DemoExecutive")
             .Log4Net()
             .DefaultBuilder()
             .XmlSerializer()
             .MsmqTransport()
                 .IsTransactional(false)
                 .PurgeOnStartup(false)
             .UnicastBus()
                 .ImpersonateSender(false)
             .CreateBus()
             .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
      }
    }
