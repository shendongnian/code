    public class CustomerOrderInfo {
      public long CustomerID;
      public decimal TotalPurchases;
    }
    public class Customer {
      public static Expression<Func<Customer, CustomerOrderInfo>> GetCustomerOrderInfo() {
        return c => new CustomerOrderInfo {
                      CustomerID = c.ID,
                      TotalPurchases = c.Orders.Where(o => o.OrderDate.Year == DateTime.Now.Year)
                                        .Sum(o => o.OrderTotalAmt)
                    };
      }
    }
    public class SomeReport {
      public void GetCustomerInfoBySalesperson(long salespersonID) {
        using (var db = new MyDataContext()) {
          var q = db.Customers
                    .Join(db.Customers.Select(Customer.GetCustomerOrderInfo()),
                          c => c.ID, i => i.CustomerID,
                          (c, i) => new { c.Name, c.Address, i.TotalPurchases })
                    .ToList();
      // etc..
        }
      }
    }
