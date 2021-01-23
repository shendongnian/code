    Enumerable<CustomerInfo> CA =
                    fruits.Cast<CustomerInfo>().(from C in DB.Customer_Addresses
                      join cust in DB.Customers
                      on C.CustomerID equals cust.ID
                      where C.CustomerID == CustomerID
                      select new
                      {
                          CustomerName=cust.Name,
                          CustomerAddress=C.Address,
                          CustomerTel=C.Telephone
                      }
                      );
    return CA;
