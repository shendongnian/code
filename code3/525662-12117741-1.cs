    CustomerDataContext dc = new CustomerDataContext();
    Table<Customer> customers = dc.GetTable<Customer>();
    Table<Product> products= dc.GetTable<Product>();
    Customer newCustomer = new Customer ();
    Product newProduct   = new Product();
    customers.InsertOnSubmit(newCustomer);
    products.InsertOnSubmit(newProduct);
    customers.Context.SubmitChanges();
    customers.Context.SubmitChanges();
    
    
    
        SubmitChanges();
    
    //Now insert associations
    ProductConsumer= new ProductConsumer();
    ProductConsumer.Consumer= newCustomer ;
    ProductConsumer.Product= newProduct  ;
   
    InsertOnSubmit(ProductConsumer)
    SubmitChanges();
