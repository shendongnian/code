    using System;
    using System.ServiceModel;
    using System.ServiceProcess;
    using QuickReturns.StockTrading.ExchangeService;
    
    namespace QuickReturns.StockTrading.ExchangeService.Hosts
    {
        public partial class ExchangeWindowsService : ServiceBase
        {
            ServiceHost host;
    
            public ExchangeWindowsService()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                Type serviceType = typeof(TradeService);
                host = new ServiceHost(serviceType);
                host.Open();
            }
    
            protected override void OnStop()
            {
                if(host != null)
                   host.Close();
            }
        }
    }
