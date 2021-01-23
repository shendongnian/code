    public class Order
    {
        public string Id { get; private set; }
        public DateTime Raised { get; private set; }
        public Money TotalValue { get; private set; }
        public Money TotalTax { get; private set; }
        public List<OrderItem> Items { get; private set; }
    
        // Available to the service layer.
        public Order(Messages.CreateOrder request, IOrderNumberGenerator numberGenerator, ITaxCalculator taxCalculator)
        {
            Raised = DateTime.UtcNow;
            Id = numberGenerator.Generate();
            Items = new List<OrderItem>();
            foreach(var item in request.InitialItems)
                AddOrderItem(item);
            UpdateTotals(taxCalculator);
        }
        private void AddOrderItemCore(Messages.AddOrderItem request)
        {
            Items.Add(new OrderItem(this, request));
        }
    
        // Available to the service layer.
        public void AddOrderItem(Messages.AddOrderItem request, ITaxCalculator taxCalculator)
        {
            AddOrderItemCore(request);
            UpdateTotals(taxCalculator);
        }
    
        private void UpdateTotals(ITaxCalculator taxCalculator)
        {
            TotalTax = Items.Sum(x => taxCalculator.Calculate(this, x));
            TotalValue = Items.Sum(x => x.Value);
        }
    }
