    public class MiniCustomerDto
    {
      public int CustomerId{get;set;}
      public String CustomerName{get;set;}
      public int OrdersCount{get;set;}
    }
    public static List<MiniCustomerDto> GetCustomerOrdersCount()
    {
            using (OrdersDbEntities context = new OrdersDbEntities())
            {
                return context.Customers.Select(c => new MiniCustomerDto
                {
                    CustId = c.CustomerId,
                    CustName = c.CustomerName,
                    OrdersCount = c.Orders.Count
                }).ToList();
            }
    }
