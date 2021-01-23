    // Command pattern
    public class ShipOrder
    {
        ITransactionFactory _transactionFactory;
    	
    	
        public OrderShipper(ITransactionFactory factory)
    	{
    		if (factory == null) throw new ArgumentNullException("factory");
    		
    		_transactionFactory = factory;
    	}
    	
    	[PrincipalPermission(Roles = "User")]
        public void Execute(Order order) 
        {
    		if (order == null) throw new ArgumentNullException("order");
    
            using (new PerformanceProfiler()) 
            {
                HandleWithRetries(() => ShipOrderInTransaction(order));
            }
        }
    
        private void ShipOrderInTransaction(Order order) 
        {
            using (var transaction = _transactionFactory.Create()) 
            {
                ShipOrderInternal(order);
    
                transaction.Commit();
            }            
        }
    
        protected void ShipOrderInternal(order) 
        {
            // bussiness logic which is divided into different protected methods.
        }
    }
