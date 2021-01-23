    string[] tempCustomerName = new string[CustomerName.Length];
    CustomerName.CopyTo(tempCustomerName, 0);
    Array.Sort(tempCustomerName, Id);
    
    CustomerName.CopyTo(tempCustomerName, 0);
    Array.Sort(tempCustomerName, CustomerDiscountCode);
    
    Array.Sort(CustomerName, CustomerRate);
