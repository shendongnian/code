    namespace Services
    {
        [System.ServiceModel.ServiceBehavior(AddressFilterMode =
             System.ServiceModel.AddressFilterMode.Prefix)]
        class BarService : Contracts.IBar
        {
            #region IBar Members
            public void DoSomething()
            {
                System.Uri endpoint = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders.To;
                Console.WriteLine("DoSomething endpoint: {0}", endpoint);
            }
        } // Ends class BarService
    } // Ends namespace Services
    class RunHost
    {
        static void HostIBar()
        {
            System.Uri uriBase = new System.Uri("net.pipe://localhost");
            System.ServiceModel.ServiceHost hostBar =
                new System.ServiceModel.ServiceHost(
                typeof(Services.BarService),
                uriBase);
            hostBar.AddServiceEndpoint(
                  typeof(Contracts.IBar) // Type implementedContract
                , namedpipeBinding // System.ServiceModel.Channels.Binding binding
                , "root/IBar" //string address
            );
            hostBar.Open();
            Console.WriteLine("Press <ENTER> to stop...");
            Console.ReadLine();
        }
    }
