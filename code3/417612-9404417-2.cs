        CreateMap<Order, OrderModel>()
            .ConvertUsing(o => new OrderModel(
                o.Id,
                o.ShippingAddress,
                Mapper.Map<IList<OrderItemModel>>(o.Items) //use static Mapper class
        ));
        CreateMap<OrderItem, OrderItemModel>();
