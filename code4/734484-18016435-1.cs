    public string GetCustomerName(int id)
        {
            Customer CustomerObj = _customer.GetCustomer(id);
            string customerName = CustomerObj.FirstName + " " + CustomerObj.LastName;
            return customerName;
        }
    
