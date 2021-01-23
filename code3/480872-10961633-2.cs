    class AddOrderViewModel {
        // So the user knows what is already ordered
        public IEnumerable<Order> PreviousOrders { get; set; }
        // Object being added (keeping a reference in case of validation errors)
        public Order CurrentOrder { get; set; }
    }
