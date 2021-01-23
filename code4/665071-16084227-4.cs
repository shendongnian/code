    public class SomeReport {
      Expression<Func<Customer, decimal>> GetCustomerOrderInfo = 
            c => c.Orders.Where(o => o.OrderDate.Year == DateTime.Now.Year)
                         .Sum(o => o.OrderTotalAmt);
      public void GetCustomerInfoBySalesperson(long salespersonID) {
        using (var db = new MyDataContext()) {
          var q = db.Customers.Where(c => c.SalespersonID == salespersonID)
                    .Select( new { c.Name, c.Address, ThisYearsPurchases = c.GetCustomerOrderInfo })
                    .ToList();
      // etc..
        }
      }
    }
