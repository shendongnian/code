    public IEnumerable<OrderDto> GetPaymentOrders(int paymentID)
    {
        return context.Payments
            .Where(p => p.ID == paymentID)
            .Select(p => p.Orders.Select(o => new OrderDto
            {
                ID = o.ID,
                //etc. mapping of more Order properties
            }))
            .SingleOrDefault();
    }
