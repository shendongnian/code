    public class Customer {
      public decimal TotalPurchasesThisYear(List<Orders> customerOrders) {
        return orders.Sum(o => o.OrderTotalAmt);
      }
    }
    
    public class SomeReport {
      public void GetCustomerInfoBySalesperson(long salespersonID) {
        using (var db = new MyDataContext()) {
          var q = db.Customers.Where(c => c.SalespersonID == salespersonID)
                              .ToList()
                              .Select(c => new { c.Name, c.Address, ThisYearPurchases = c.TotalPurchasesThisYear(db.Orders.Where(w => w.CustomerID == ID).ToList() })
                              .ToList();
          // etc..
        }
      }
    }
