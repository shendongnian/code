It seems you never SET your property... You have it defined as a List&lt;OrderItemInfo&gt; *type* but you never initialize it to an *instance* of that type. Try initializing it in a constructor:
    public class OrderInfo
    {
        public OrderInfo
        {
            OrderiTems = new List<OrderItemInfo>();
        }
    }
