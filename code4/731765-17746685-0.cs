    class OrderedPoint
    {
        public int Order {get;set;}
        public PointF Point {get;set;}
        public static int CompareByOrder(OrderedPoint x, OrderedPoint y)
        {
            return x.Order.CompareTo(y.Order);
        }
    }
    List<OrderedPoint> list;
    // TODO: Fill it
    list.Sort(OrderedPoint.CompareByOrder);
    
