    public class OrderStatusConverter: ITypeConverter<OrderStatus, OrderStatusDto>
    {
        public OrderStatusDto Convert(OrderStatus source)
        {
            return (OrderStatusDto)source;
        }
    }
