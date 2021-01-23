    [Interceptor(typeof(SecurityInterceptor))]
    public class OrderManagementService : IOrderManagementService
    {
        [RequiredPermission(Permissions.CanCreateOrder)]
        public virtual Guid CreateOrder(string orderCode)
        {   
            Order order = new Order(orderCode);
            order.Save(order); // ActiveRecord-like implementation
            return order.Id;
        }
    } 
