    [Insert]
    public void InsertJeopardyModel(CustomerDTO jeopardy)
    {
        CustomerDTO customerFromDB = CreateCustomerDTOCore(customer);
        jeopardy.Id = customerFromDB.Id;
        jeopardy.MyProperty = customerFromDB.MyDBEquivalentProperty;
    }
