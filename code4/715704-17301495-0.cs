    public class OrderService : IOrderService
    {
        private void ProcessOrder(Order order)
        {
            var ra = new AuditMetadataResourceAccess();
            MethodInfo[] fieldsToLog = ra.GetLoggingFields(typeof(OrderDetal));
    
            if (fieldsToLog.Any())
            {
                var logger = new LogingEngine();
                logger.Log(fieldsToLog, order.OrderDetails);
            }
        }
    }
