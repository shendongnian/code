    class CustomerDetailsComparer: IEqualityComparer<CustomerDetail>
    {
        public bool Equals(CustomerDetail x, CustomerDetail y)
        {
    
            if (Object.ReferenceEquals(x, y)) return true;
    
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.CustomerId == y.CustomerId;
        }
    
    
        public int GetHashCode(CustomerDetail cd)  
        {
             // Do something here
        }  
    }
    // ...
    
    DbContext.CustomerDetails.Distinct(new CustomerDetailsComparer());
