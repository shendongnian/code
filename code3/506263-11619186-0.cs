    class CustomerInfo   // new class
    {
        private string CustomerName;
        private string CustomerAddress;
        private string CustomerTel;
    }
  
    public IEnumerable<CustomerInfo> ReadAddressForCustomer(int CustomerID)  //return new class
    {
        ProjectServiceForCustomerDataContext DB = new ProjectServiceForCustomerDataContext();
        var CA =  from C in DB.Customer_Addresses
                  join cust in DB.Customers
                  on C.CustomerID equals cust.ID
                  where C.CustomerID == CustomerID
                  select new CustomerInfo    // instantiate new concrete type
                  {
                      CustomerName=cust.Name,
                      CustomerAddress=C.Address,
                      CustomerTel=C.Telephone
                  }   // don't call ToList anymore
        return CA;
    }
