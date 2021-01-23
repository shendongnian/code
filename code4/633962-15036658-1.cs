    static public SharedStorage
    {
        public string OrderNumber { get; set; }
    }
    
    // Somewhere in your code
    
    SharedStorage.OrderNumber = a.orderNumber();
    
    // Somewhere else in your code
    
    string orderNumber = SharedStorage.OrderNumber;
