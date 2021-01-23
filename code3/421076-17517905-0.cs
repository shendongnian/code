    private IOrderRepository _orderservice = null;
    public EmailService(IOrderService orderservice)
    {
        _orderservice = orderservice;
    }
    public void SendEmails()
    {
        _orderService.GetAll();
    }
}
