       ViewResult Index()
    {
       CustomeActivityModel Model = new CustomeActivityModel();
       Model.CustomerList EFContext.Customers;
       Model.SalesList EFContext.Sales;
       Model.OrdersList EFContext.Orders;
       Return View(Model);
    }
