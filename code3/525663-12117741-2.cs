    CustomerDataContext dc = new CustomerDataContext();
    Table<Customer> customers = dc.GetTable<Customer>();
    Table<Product> products= dc.GetTable<Product>();
    Table<ProductConsumer> ProductConsumers= dc.GetTable<ProductConsumer>();
    Customer newCustomer = new Customer ();
    Product newProduct   = new Product();
    customers.InsertOnSubmit(newCustomer);
    products.InsertOnSubmit(newProduct);
    customers.Context.SubmitChanges();
    products.Context.SubmitChanges();
    //Now insert associations
    ProductConsumer= new ProductConsumer();
    ProductConsumer.Consumer= newCustomer ;
    ProductConsumer.Product= newProduct  ;
    
    ProductConsumers.InsertOnSubmit(ProductConsumer)
    ProductConsumers.Context.SubmitChanges();
