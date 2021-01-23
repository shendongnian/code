    public class OrdersService : IOrdersService
    {
            private readonly ISession SessionMDII;
            private readonly ISession SessionSpedizioni;
    
            public OrdersService(ISession sessionMDII, ISession sessionSpedizioni)
            {
                this.SessionMDII = sessionMDII;
                this.SessionSpedizioni = sessionSpedizioni;
            }
    	
    	...
    }
