    private void CreateInstance(Product product)
    {
        Transaction transaction = new Sale(product);
    }
    private void CreateInstance(BusinessService service)
    {
        Transaction transaction = new ServiceCharge(service);
    }
